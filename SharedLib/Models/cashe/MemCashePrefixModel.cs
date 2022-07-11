////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Префикс пути к ключам данным
    /// </summary>
    public class MemCashePrefixModel
    {
        /// <summary>
        /// Пространство имён ключей доступа к данным
        /// </summary>
        public string Namespace { get; }

        /// <summary>
        /// Словарь имён ключей доступа к данным
        /// </summary>
        public string Dictionary { get; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="set_namespace">Пространство имён</param>
        /// <param name="set_dict">Словарь</param>
        public MemCashePrefixModel(string set_namespace, string set_dict)
        {
            Namespace = set_namespace;
            Dictionary = set_dict;
        }

        /// <summary>
        /// Преобразовать объект префикса в строку
        /// </summary>
        /// <returns>Строковое представление объекта префикса</returns>
        public override string ToString() => $"{Namespace}:{Dictionary}";
    }
}
