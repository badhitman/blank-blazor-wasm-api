////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLib.Models
{
    /// <summary>
    /// Элементы перечисления
    /// </summary>
    [Index(nameof(Name), nameof(OwnerEnumId), IsUnique = true)]
    //[Index(nameof(SortIndex), nameof(OwnerEnumId), IsUnique = true)]
    public class EnumDesignItemModelDB : EntryDescriptionModel
    {
        /// <summary>
        /// Системное имя (имя типа/класса C#)
        /// </summary>
        [RegularExpression(GlobalStaticConstants.SYSTEM_CODE_NAME_TEMPLATE, ErrorMessage = "Системное имя может содержать только буквы латинского алфавита (a-zA-Z)")]
        public new string Name { get; set; }

        /// <summary>
        /// Индекс сортировки
        /// </summary>
        public uint SortIndex { get; set; }

        public int OwnerEnumId { get; set; }

        /// <summary>
        /// Владелец элемента/перечисления
        /// </summary>
        public EnumDesignModelDB OwnerEnum { get; set; }

        public static explicit operator EnumDesignItemModelDB(EnumItemActionRequestModel v)
        {
            return new EnumDesignItemModelDB()
            {
                Name = v.Name,
                Description = v.Description,
                OwnerEnumId = v.OwnerEnumId
            };
        }
    }
}
