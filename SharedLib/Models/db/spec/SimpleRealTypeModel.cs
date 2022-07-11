////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Простейший вещественный тип
    /// </summary>
    public class SimpleRealTypeModel : RealTypeModel
    {
        public static explicit operator SimpleRealTypeModel(DocumentDesignModelDB v)
        {
            return new SimpleRealTypeModel()
            {
                Id = v.Id,
                Description = v.Description,
                IsDeleted = v.IsDeleted,
                Name = v.Name,
                SystemCodeName = v.SystemCodeName,
            };
        }

        public static explicit operator SimpleRealTypeModel(EnumDesignModelDB v)
        {
            return new SimpleRealTypeModel()
            {
                Id = v.Id,
                Description = v.Description,
                IsDeleted = v.IsDeleted,
                Name = v.Name,
                SystemCodeName = v.SystemCodeName,
            };
        }
    }
}