////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Конфигурация генерации кода
    /// </summary>
    public class CodeGeneratorConfigModel
    {
        /// <summary>
        /// О проекте
        /// </summary>
        public NameSpacedModel ProjectInfo { get; set; }

        /// <summary>
        /// Путь размещения файлов перечисления
        /// </summary>
        public string EnumDirectoryPath { get; set; } = "enums";

        /// <summary>
        /// Путь размещения файлов документов
        /// </summary>
        public string DocumentsMastersDbDirectoryPath { get; set; } = "db";
        public string AccessDbDirectoryPath { get; set; } = "access_table";
    }
}
