////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorWasmApp
{
    /// <summary>
    /// Предоставляет информацию о состоянии проверки подлинности текущего пользователя.
    /// </summary>
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        readonly SessionMarkerLiteModel _session_marker;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="set_session_marker">иаркер сессии</param>
        public CustomAuthStateProvider(SessionMarkerLiteModel set_session_marker)
        {
            _session_marker = set_session_marker;
        }

        /// <summary>
        /// Асинхронно получает Microsoft.AspNetCore.Components.Authorization.AuthenticationState, описывающий текущего пользователя.
        /// </summary>
        /// <returns>Task, который при решении дает экземпляр Microsoft.AspNetCore.Components.Authorization.AuthenticationState, описывающий текущего пользователя.</returns>
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            List<Claim> claims = new List<Claim>();
            if (!string.IsNullOrEmpty(_session_marker.Login))
            {
                claims.AddRange(new Claim[]
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, _session_marker.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, _session_marker.AccessLevelUser.ToString())
                });

                // создаем объект ClaimsIdentity
                ClaimsIdentity id = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                ClaimsPrincipal id_claim = new ClaimsPrincipal(id);
                return Task.FromResult(new AuthenticationState(id_claim));
            }
            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        }

        /// <summary>
        /// Вызывает событие Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider.AuthenticationStateChanged.
        /// </summary>
        public new void AuthenticationStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
