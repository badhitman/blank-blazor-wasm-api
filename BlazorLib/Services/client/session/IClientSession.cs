////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib
{
    /// <summary>
    /// Хранение сессии пользователя в кукисах браузера
    /// </summary>
    public interface IClientSession
    {
        /// <summary>
        /// Сохранить маркер сессии в кукисах браузера
        /// </summary>
        /// <param name="set_session_marker">Маркер сессии</param>
        public Task SaveSessionAsync(SessionMarkerLiteModel set_session_marker);

        /// <summary>
        /// Прочитать маркер сессии из кукисов браузера
        /// </summary>
        /// <returns>Маркер (текущий) сессии</returns>
        public Task<SessionMarkerLiteModel> ReadSessionAsync();

        /// <summary>
        /// Удалить маркер сессии из кукисов браузера
        /// </summary>
        public Task RemoveSessionAsync();

        /// <summary>
        /// Выйти из сессии пользователя
        /// </summary>
        /// <returns></returns>
        public Task<ResponseBaseModel> LogoutAsync();
    }
}
