////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Префиксы маршрутов контроллеров (+ Refit)
    /// используется для генератора кода в контроллерах и службах refit
    /// </summary>
    public enum RouteMethodsPrefixesEnum
    {
        /// <summary>
        /// Добавить/создать один объект
        /// </summary>
        AddSingle,

        /// <summary>
        /// Добавить/создать коллекцию объектов
        /// </summary>
        AddRange,

        /// <summary>
        /// Получить один объект по идентификатору
        /// </summary>
        GetSingleById,

        /// <summary>
        /// Получить коллекцию элементов по идентификаторам
        /// </summary>
        GetRangeByIds,

        /// <summary>
        /// Получить коллекцию элементов по идентификатору ведущего объекта-владельца
        /// </summary>
        GetRangeByOwnerId,

        /// <summary>
        /// Обновить один объект
        /// </summary>
        UpdateSingle,

        /// <summary>
        /// Обновить коллекцию объектов
        /// </summary>
        UpdateRange,

        /// <summary>
        /// Пометить объект по идентификатору
        /// </summary>
        MarkAsDeleteById,

        /// <summary>
        /// Удалить (безвозвартно) объект по идентификатору
        /// </summary>
        RemoveSingleById,

        /// <summary>
        /// Удалить (безвозвартно) колекцию объектов по идентификаторам
        /// </summary>
        RemoveRangeByIds
    }
}
