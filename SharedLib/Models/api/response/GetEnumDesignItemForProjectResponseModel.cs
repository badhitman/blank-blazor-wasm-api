////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Результат запроса проекта и элемента перечисления
    /// </summary>
    public class GetEnumDesignItemForProjectResponseModel: UserProjectResponseModel
    {
        /// <summary>
        /// Элемент перечисления
        /// </summary>
        public EnumDesignItemModelDB EnumDesignItem { get; set; }
    }
}