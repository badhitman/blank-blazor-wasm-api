////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Результат запроса перечисления
    /// </summary>
    public class EnumDesignResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Запрашиваемый объект
        /// </summary>
        public EnumDesignModelDB EnumDesign { get; set; }

        /// <summary>
        /// Текущая ссылка пользователя на проект
        /// </summary>
        public UserToProjectLinkModelDb CurrentUserLinkProject { get; set; }
    }
}