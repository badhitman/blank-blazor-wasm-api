////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Объект перечисления
    /// </summary>
    public class EnumDesignModel : RealTypeModel
    {
        public static explicit operator EnumDesignModel(EnumDesignModelDB v)
        {
            return v is null
                ? null
                : new EnumDesignModel()
                {
                    Id = v.Id,
                    Description = v.Description,
                    Name = v.Name,
                    IsDeleted = v.IsDeleted,
                    SystemCodeName = v.SystemCodeName,
                };
        }
    }
}