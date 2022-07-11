////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib
{
    /// <summary>
    /// Поддержка сохранения данных в БД
    /// </summary>
    public interface ISavingChanges
    {
        /// <summary>
        /// Сохранить текущие изменения в БД
        /// </summary>
        /// <param name="cashe_upd">Актуализация кеширования</param>
        /// <returns>Количество строк затронутых (или созданных) объектов/строк данных</returns>
        public Task<int> SaveChangesAsync(Dictionary<string, string?>? cashe_upd = null);
    }
}