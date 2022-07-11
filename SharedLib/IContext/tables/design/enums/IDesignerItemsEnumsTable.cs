////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib
{
    /// <summary>
    /// Элементы перечисления: Доступ к таблице базы данных
    /// </summary>
    public interface IDesignerItemsEnumsTable : ISavingChanges
    {
        /// <summary>
        /// Получить элемент перечисления
        /// </summary>
        /// <param name="enum_item_systemcode_name">Системное кодовое имя элемента перечисления</param>
        /// <param name="enum_id">Идентификатор перечисления</param>
        /// <returns>Элемент перечисления</returns>
        public Task<EnumDesignItemModelDB> GetEnumItemAsync(string enum_item_systemcode_name, int enum_id);

        /// <summary>
        /// Обновить элемент перечисления
        /// </summary>
        /// <param name="enum_item_db">Элемент перечисления</param>
        /// <param name="auto_save">Автоматическое сохранение изменений в БД</param>
        public Task UpdateEnumItemAsync(EnumDesignItemModelDB enum_item_db, bool auto_save = true);

        /// <summary>
        /// Получить следующий свободный индекс сортировки для элемента перечисления
        /// </summary>
        /// <param name="ownerEnumId">Идентификатор перечисления в котором следует определить индекс сортировки</param>
        /// <returns>Индекс сортировки, следующий за максимальным</returns>
        public Task<uint> NextSortIndexAsync(int ownerEnumId);

        /// <summary>
        /// Создать элемент перечисления
        /// </summary>
        /// <param name="enum_item_db">Новый элемент перечисления</param>
        /// <param name="auto_save">Автоматическое сохранение изменений в БД</param>
        public Task AddEnumItemAsync(EnumDesignItemModelDB enum_item_db, bool auto_save = true);

        /// <summary>
        /// Получить элементы перечисления
        /// </summary>
        /// <param name="ownerEnumId">Идентификатор перечисления</param>
        /// <returns>элементы перечисления</returns>
        public Task<IEnumerable<EnumDesignItemModelDB>> GetEnumItemsAsync(int ownerEnumId);

        /// <summary>
        /// Получить элемент перечисления по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор элемента перечисления</param>
        /// <returns>Элемент перечисления</returns>
        public Task<EnumDesignItemModelDB> GetEnumItemAsync(int id);

        /// <summary>
        /// Обновить элементы перечисления
        /// </summary>
        /// <param name="upd_items">элементы перечисления</param>
        /// <param name="auto_save">Автоматическое сохранение изменений в БД</param>
        public Task UpdateEnumItemsRangeAsync(IEnumerable<EnumDesignItemModelDB> upd_items, bool auto_save = true);

        /// <summary>
        /// Удалить (безвозвратно) элемент перечисления
        /// </summary>
        /// <param name="enum_design_item">элемент перечисления для удаления</param>
        /// <param name="auto_save">Автоматическое сохранение изменений в БД</param>
        public Task DeleteEnumItemAsync(EnumDesignItemModelDB enum_design_item, bool auto_save = true);
    }
}
