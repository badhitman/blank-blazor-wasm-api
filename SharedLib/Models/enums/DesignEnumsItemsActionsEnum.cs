////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Models
{
    /// <summary>
    /// Виды операций над элементами перечисления
    /// </summary>
    public enum DesignEnumsItemsActionsEnum
    {
        /// <summary>
        /// Инверсия пометки на удаление
        /// </summary>
        DeleteMarkToggle,

        /// <summary>
        /// Удалить элемент перечисления безвозвратно
        /// </summary>
        TrashElement,

        /// <summary>
        /// Сдвинуь выше
        /// </summary>
        MoveUp,

        /// <summary>
        /// Сдвинуть ниже
        /// </summary>
        MoveDown,

        /// <summary>
        /// Обновить наименование/описание элемента перечисления
        /// </summary>
        UpdateNameAndDescriotion,

        /// <summary>
        /// Создать новый элемент перечисления
        /// </summary>
        Create
    }
}
