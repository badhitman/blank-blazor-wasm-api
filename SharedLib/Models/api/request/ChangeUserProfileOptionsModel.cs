////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Изменение параметра пользователя
    /// </summary>
    public class ChangeUserProfileOptionsModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Опциия изменения параметра пользователя
        /// </summary>
        public string? OptionAttribute { get; set; }
    }
}
