////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Простой объект с именем, пространсвом имён и описанием (без идентификатора/ID)
    /// </summary>
    public class NameSpacedDescriptionSimpleModel : NameDescriptionSimpleModel
    {
        /// <summary>
        /// Пространсво имён
        /// </summary>
        public string NameSpace { get; set; } = string.Empty;

        public static explicit operator ProjectModelDB(NameSpacedDescriptionSimpleModel v)
        {
            return new ProjectModelDB()
            {
                Name = v.Name,
                Description = v.Description,
                IsDeleted = false,
                NameSpace = v.NameSpace
            };
        }

        public static explicit operator NameSpacedDescriptionSimpleModel(ProjectModelDB v)
        {
            return new NameSpacedDescriptionSimpleModel()
            {
                Name = v.Name,
                Description = v.Description,
                NameSpace = v.NameSpace
            };
        }
    }
}