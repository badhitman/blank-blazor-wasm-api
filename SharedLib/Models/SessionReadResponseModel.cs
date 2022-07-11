////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Маркер сессии пользователя (результат запроса)
    /// </summary>
    public class SessionReadResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Маркер сессии пользователя
        /// </summary>
        public SessionMarkerModel SessionMarker { get; set; }
    }
}