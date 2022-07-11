////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib;
using SharedLib.MemCash;
using SharedLib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using StackExchange.Redis;

namespace ServerLib
{
    /// <inheritdoc/>
    public class SessionService : SessionLiteService, ISessionService
    {
        readonly IOptions<ServerConfigModel> _config;
        readonly IHttpContextAccessor _http_context;
        readonly IManualMemoryCashe _mem_cashe;

        /// <summary>
        /// Маркер сессии пользователя
        /// </summary>
        public SessionMarkerModel SessionMarker { get; set; } = new SessionMarkerModel(0, string.Empty, AccessLevelsUsersEnum.Anonim, string.Empty, false);

        /// <summary>
        /// Конструктор
        /// </summary>
        public SessionService(IHttpContextAccessor set_http_context, IOptions<ServerConfigModel> set_config, IManualMemoryCashe set_mem_cashe)
        {
            _http_context = set_http_context;
            _config = set_config;
            _mem_cashe = set_mem_cashe;
        }

        /// <inheritdoc/>
        public async Task<List<UserSessionModel>> GetUserSessionsAsync(string login)
        {
            List<UserSessionModel> res = new List<UserSessionModel>();

            string user_session_data = null;
            string[] data_segments;

            string user_session_key = null;
            string[] user_session_key_segments;

            List<RedisKey>? sessions = _mem_cashe.FindKeys(new MemCashePrefixModel(GlobalStaticConstants.SESSION_MEMCASHE_NAMESPASE, $"{login}_*"));
            foreach (RedisKey key_session in sessions)
            {
                user_session_key = key_session.ToString();
                user_session_key_segments = user_session_key.Split(":");
                if (user_session_key_segments.Length != 3)
                    continue;

                user_session_data = await _mem_cashe.GetStringValueAsync(key_session);
                data_segments = user_session_data.Split("|");
                if (data_segments.Length != 2)
                    continue;

                if (!Enum.TryParse(user_session_key_segments[1][($"{login}_".Length)..], out AccessLevelsUsersEnum user_level))
                    continue;

                res.Add(new UserSessionModel()
                {
                    DateTimeStart = DateTime.Parse(data_segments[0]),
                    IPAddressClient = data_segments[1],
                    GuidTokenSession = user_session_key_segments[2],
                    Level = user_level
                });
            }
            return res.OrderByDescending(x => x.DateTimeStart).ToList();
        }

        /// <inheritdoc/>
        public async Task InitSession()
        {
            Guid token = ReadTokenFromRequest();
            if (token == Guid.Empty)
            {
                SessionMarker?.Reload(0, string.Empty, AccessLevelsUsersEnum.Anonim, string.Empty);
                return;
            }
            GuidToken = token.ToString();

            string token_marker = await _mem_cashe.GetStringValueAsync(new MemCasheComplexKeyModel(GuidToken, UsersAuthenticateService.PrefRedisSessions));

            if (string.IsNullOrEmpty(token_marker))
            {
                GuidToken = string.Empty;

                return;
            }

            SessionMarker = new SessionMarkerModel(token_marker);

            if (string.IsNullOrEmpty(SessionMarker.Login))
            {
                SessionMarker?.Reload(0, string.Empty, AccessLevelsUsersEnum.Anonim, string.Empty);
            }
            else
            {
                SessionMarker.Token = token.ToString();
                int seconds_session = SessionMarker.IsLongTimeSession ? _config.Value.CookiesConfig.LongSessionCookieExpiresSeconds : _config.Value.CookiesConfig.SessionCookieExpiresSeconds;

                MemCasheComplexKeyModel? f_session_mkey = new MemCasheComplexKeyModel(SessionMarker.Token, UsersAuthenticateService.PrefRedisSessions);
                MemCasheComplexKeyModel? d_session_mkey = new MemCasheComplexKeyModel(SessionMarker.Token, new MemCashePrefixModel(GlobalStaticConstants.SESSION_MEMCASHE_NAMESPASE, $"{SessionMarker.Login}_{SessionMarker.AccessLevelUser}"));

                string? d_session = await _mem_cashe.GetStringValueAsync(d_session_mkey);
                if (string.IsNullOrEmpty(d_session))
                {
                    await _mem_cashe.RemoveKeyAsync(f_session_mkey);
                }
                else
                {
                    await _mem_cashe.UpdateValueAsync(f_session_mkey, SessionMarker.ToString(), TimeSpan.FromSeconds(seconds_session));
                    await _mem_cashe.UpdateValueAsync(d_session_mkey, d_session, TimeSpan.FromSeconds(seconds_session + 60));
                }
            }
        }

        /// <inheritdoc/>
        public Guid ReadTokenFromRequest()
        {
            if (_http_context.HttpContext.Request.Headers.TryGetValue(_config.Value.CookiesConfig.SessionTokenName, out StringValues tok))
            {
                string raw_token = tok.FirstOrDefault() ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(raw_token) && Guid.TryParse(raw_token, out Guid parsed_guid))
                {
                    return parsed_guid;
                }
            }

            return Guid.Empty;
        }

        /// <inheritdoc/>
        public async Task KillAllSessionsForUserAsync(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
                return;

            List<UserSessionModel>? sessions = await GetUserSessionsAsync(login);
            if (sessions?.Any() != true)
                return;

            sessions.ForEach(async x =>
            {
                await _mem_cashe.RemoveKeyAsync(UsersAuthenticateService.PrefRedisSessions, x.GuidTokenSession);
                await _mem_cashe.RemoveKeyAsync(new MemCashePrefixModel(GlobalStaticConstants.SESSION_MEMCASHE_NAMESPASE, $"{login}_{x.Level}"), x.GuidTokenSession);
            });
        }
    }
}
