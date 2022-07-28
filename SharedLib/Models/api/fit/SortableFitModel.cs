////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    public class SortableFitModel : BaseFitModel
    {
        /// <summary>
        /// Индекс сортировки
        /// </summary>
        public uint SortIndex { get; set; }

        public static explicit operator SortableFitModel(EnumDesignItemModelDB v)
        {
            return new SortableFitModel()
            {
                Id = v.Id,
                Description = v.Description,
                IsDeleted = v.IsDeleted,
                Name = v.Name,
                SortIndex = v.SortIndex
            };
        }
    }
}
