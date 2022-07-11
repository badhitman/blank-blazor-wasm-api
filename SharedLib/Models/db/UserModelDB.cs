////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLib.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>    
    public class UserModelDB : EntryCreatedModel
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public UserModelDB() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        public UserModelDB(string name) : base(name) { }

        /// <summary>
        /// Хешь пароля пользователя
        /// </summary>
        public UserPasswordModelDb Password { get; set; }

        /// <summary>
        /// Профиль пользователе (Login, E-mail)
        /// </summary>
        public UserProfileModelDB Profile { get; set; }

        /// <summary>
        /// Метаданные пользователя (Email, Уровень доступа/прав пользователя, Тип подтверждения учётной записи пользователя)
        /// </summary>
        public UserMetaModelDB Metadata { get; set; }
    }
}