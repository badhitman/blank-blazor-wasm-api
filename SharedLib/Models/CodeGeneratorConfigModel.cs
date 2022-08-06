﻿////////////////////////////////////////////////
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
        /// Путь размещения файлов моделей перечисления
        /// </summary>
        public string EnumDirectoryPath { get; set; } = "enums";

        /// <summary>
        /// Путь размещения файлов моделей документов
        /// </summary>
        public string DocumentsMastersDbDirectoryPath { get; set; } = "db";

        /// <summary>
        /// Папка размещения инфраструктуры доступа к данным
        /// </summary>
        public string AccessDataDirectoryPath { get; set; } = "access_table";

        /// <summary>
        /// Папака размещения файлов контроллеров
        /// </summary>
        public string ControllersDirectoryPath { get; set; } = "gen_controllers";

        /// <summary>
        /// Папака размещения файлов клиентских/Refit служб для взаимодействия с api/rest контроллерами
        /// </summary>
        public string RefitClientServicesDirName { get; set; } = "refit";
    }
}
