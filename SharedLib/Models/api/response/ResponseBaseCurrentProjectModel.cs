////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Базовй ответ на запрос с указанием идентификатора проекта
    /// </summary>
    public class ResponseBaseCurrentProjectModel : ResponseBaseModel
    {
        /// <summary>
        /// Идентификатор текущего проекта
        /// </summary>
        public int CurrentEditProject { get; set; }
    }
}