////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Перечисление (лёгкая модель)
    /// </summary>
    public class EnumFitModel : BaseFitRealTypeModel
    {
        /// <summary>
        /// Элементы/состав перечисления
        /// </summary>
        public IEnumerable<SortableFitModel> EnumItems { get; set; }

        public static explicit operator EnumFitModel(EnumDesignModelDB v)
        {
            return new EnumFitModel()
            {
                Description = v.Description,
                Id = v.Id,
                IsDeleted = v.IsDeleted,
                Name = v.Name,
                SystemCodeName = v.SystemCodeName,
                EnumItems = v.EnumItems.Select(x => (SortableFitModel)x)
            };
        }
    }
}
