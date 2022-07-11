////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    /// <summary>
    /// Простой объект с идентийикатором/ID, пространством имён, именем и описанием
    /// </summary>
    public class IdNameSpacedDescriptionSimpleModel : IdNameDescriptionSimpleModel
    {
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(GlobalStaticConstants.NAME_SPACE_TEMPLATE, ErrorMessage = "Не корректное пространство имени")]
        public string NameSpace { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public static explicit operator ProjectModelDB(IdNameSpacedDescriptionSimpleModel v)
        {
            return new ProjectModelDB()
            {
                Name = v.Name,
                Description = v.Description,
                IsDeleted = false,
                Id = v.Id,
                NameSpace = v.NameSpace
            };
        }

        /// <summary>
        /// Приведение типа ProjectModelDB к IdNameDescriptionSimpleModel
        /// </summary>
        /// <param name="v"></param>
        public static explicit operator IdNameSpacedDescriptionSimpleModel(ProjectModelDB v)
        {
            return new IdNameSpacedDescriptionSimpleModel()
            {
                Name = v.Name,
                Description = v.Description,
                Id = v.Id,
                NameSpace = v.NameSpace
            };
        }
    }
}
