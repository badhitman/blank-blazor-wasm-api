////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Ссылки пользователей на проекты (результат запроса)
    /// </summary>
    public class GetLinksProjectsResponseModel : ResponseBaseModel
    {
        public ICollection<UserToProjectLinkModelDb> Links { get; set; }
    }
}