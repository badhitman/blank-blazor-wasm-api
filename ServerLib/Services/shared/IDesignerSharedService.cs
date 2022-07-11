////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace ServerLib
{
    /// <summary>
    /// Вспомогательный сервис работы со дизайн-объектами
    /// </summary>
    public interface IDesignerSharedService
    {
        /// <summary>
        /// Проверка прав текущего пользователя
        /// </summary>
        /// <returns></returns>
        public Task<UserProjectResponseModel> CheckLiteAsync();

        /// <summary>
        /// Комлексная проверка объекта: проверка прав + проверка корректности и уникальноси системного имени объекта
        /// </summary>
        /// <param name="obj_id">Идентификатор объекта</param>
        /// <param name="obj_name">Имя объекта</param>
        /// <param name="obj_systemcode">Системный код объекта</param>
        /// <param name="obj_type">Тип проверяемого объекта</param>
        /// <returns>Резульатт проверки</returns>
        public Task<UserProjectResponseModel> CheckComplexAsync(int obj_id, string obj_name, string obj_systemcode, Type obj_type);
    }
}
