////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Проект пользовательский
    /// </summary>
    public class ProjectModelDB : EntryDescriptionModel
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public ProjectModelDB() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ProjectModelDB(EntryModel cast)
        {
            Id = cast.Id;
            Name = cast.Name;
            IsDeleted = cast.IsDeleted;
        }

        /// <summary>
        /// Пространство имён
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(GlobalStaticConstants.NAME_SPACE_TEMPLATE,ErrorMessage = "Не корректное пространство имени")]
        public string NameSpace { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Имя проекта</param>
        public ProjectModelDB(string name) : base(name) { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Название проекта</param>
        /// <param name="descripton">Описание проекта</param>
        public ProjectModelDB(string name, string descripton) : base(name, descripton) { }

        /// <summary>
        /// Пользователи, связанные с проектом
        /// </summary>
        public ICollection<UserToProjectLinkModelDb>? UsersLinks { get; set; }
    }
}