////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Вложенная EntryModel
    /// </summary>
    public class NodeModel : EntryModel
    {
        /// <summary>
        /// Идентификатор родителя
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public NodeModel() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id">Идентификатор объекта</param>
        /// <param name="name">Наименование объекта</param>
        public NodeModel(int id, string name) : base(name) { Id = id; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Наименование объекта</param>
        /// <param name="parent_id">Идентификатор родительского объекта</param>
        public NodeModel(string name, int parent_id) : base(name) { ParentId = parent_id; }
    }
}
