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
    /// Виды операций над объектами
    /// </summary>
    public enum DesignObjectsItemsActionsEnum
    {
        /// <summary>
        /// Инверсия пометки на удаление
        /// </summary>
        DeleteMarkToggleAction,

        /// <summary>
        /// Удалить элемент безвозвратно
        /// </summary>
        TrashAction,

        /// <summary>
        /// Сдвинуь выше
        /// </summary>
        MoveUpAction,

        /// <summary>
        /// Сдвинуть ниже
        /// </summary>
        MoveDownAction,

        /// <summary>
        /// Обновить наименование/описание элемента перечисления
        /// </summary>
        UpdateAction,

        /// <summary>
        /// Создать новый элемент
        /// </summary>
        CreateAction
    }
}
