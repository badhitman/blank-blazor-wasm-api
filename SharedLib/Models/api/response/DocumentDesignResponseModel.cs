////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Результат запроса документа
    /// </summary>
    public class DocumentDesignResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Запрашиваемый объект
        /// </summary>
        public DocumentDesignModelDB DocumentDesign { get; set; }

        /// <summary>
        /// Текущая ссылка пользователя на проект
        /// </summary>
        public UserToProjectLinkModelDb CurrentUserLinkProject { get; set; }
    }
}