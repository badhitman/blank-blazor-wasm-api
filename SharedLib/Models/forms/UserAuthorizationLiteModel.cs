////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Объект пользователя для авторизация (создание сессии)
    /// </summary>
    public class UserAuthorizationLiteModel
    {
        /// <summary>
        /// Логин пользователя для авторизации сессии
        /// </summary>
        [StringLength(15, MinimumLength = 4, ErrorMessage = "Длина логина должна быть от 4 до 15 символов")]
        [RegularExpression(@"[A-Za-z0-9_-]+", ErrorMessage = "Логин может содержать только буквы, цыфры, дефис и символ подчёркивания")]
        public string Login { get; set; } = string.Empty;

        /// <summary>
        /// Пароль пользователя для авторизации
        /// </summary>
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Длина пароля должна быть от 8 до 30 символов")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Код проверки reCAOTCHA формы
        /// </summary>
        public string ResponseReCAPTCHA { get; set; } = string.Empty;
    }
}
