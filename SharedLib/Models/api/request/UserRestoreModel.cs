////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Запрпос восстановления доступа к учётной записи по логину или паролю
    /// </summary>
    public class UserRestoreModel
    {
        /// <summary>
        /// Логин пользователя, доступ к которому требуется восстановить
        /// </summary>
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// E-mail пользоватлея, доступ к которому требуется восстановить
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Проверочный код reCAPTCHA
        /// </summary>
        public string ResponseReCAPTCHA { get; set; } = string.Empty;
    }
}
