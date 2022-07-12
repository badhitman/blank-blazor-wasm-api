////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Результат операции добавления ссылки пользователя на проект
    /// </summary>
    public class AddLinkProjectResultModel : ResponseBaseModel
    {
        /// <summary>
        /// созданная ссылка
        /// </summary>
        public UserToProjectLinkModelDb LinkProject { get; set; }
    }
}