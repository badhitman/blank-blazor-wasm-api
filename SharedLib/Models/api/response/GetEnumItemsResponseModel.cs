////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Элементы перечисления (результат запроса)
    /// </summary>
    public class GetEnumItemsResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Элементы перечисления
        /// </summary>
        public IEnumerable<EnumDesignItemModelDB> EnumItems { get; set; }
    }
}