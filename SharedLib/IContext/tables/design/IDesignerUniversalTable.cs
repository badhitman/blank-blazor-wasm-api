////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDesignerUniversalTable
    {
        /// <summary>
        /// Найти объекты по системному кодовому имени в контексте
        /// </summary>
        /// <param name="project_id">Проект, в контексте которого следует произвести поиск</param>
        /// <param name="object_type">Тип еонтрольного объекта</param>
        /// <param name="object_id">Идентификатор контрольного объекта</param>
        /// <param name="system_code_name">Системное кодовое имя объекта для поиска</param>
        /// <returns>Объекты, которые существуют в указанном проекте с указанным системным кодовым именем</returns>
        public Task<EntryModel?> FindObjectsBySystemCodeName(string system_code_name, int project_id, Type object_type, int object_id);
    }
}
