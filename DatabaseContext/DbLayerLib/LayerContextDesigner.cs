////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SharedLib;

namespace DbLayerLib
{
    /// <summary>
    /// Промежуточный/общий слой контекста базы данных
    /// </summary>
    public partial class LayerContext : DbContext
    {
        /// <summary>
        /// Пользовательские проекты
        /// </summary>
        public DbSet<ProjectModelDB> DesignProjects { get; set; }

        /// <summary>
        /// Связи пользователей с пользовательскими проектами
        /// </summary>
        public DbSet<UserToProjectLinkModelDb> DesignProjectsToUsersLinks { get; set; }

        /// <summary>
        /// Перечисления
        /// </summary>
        public DbSet<EnumDesignModelDB> DesignEnums { get; set; }

        /// <summary>
        /// Элементы перечислений
        /// </summary>
        public DbSet<EnumDesignItemModelDB> DesignEnumsItems { get; set; }

        /// <summary>
        /// Документы
        /// </summary>
        public DbSet<DocumentDesignModelDB> DesignDocuments { get; set; }

        /// <summary>
        /// Табличные части документов
        /// </summary>
        public DbSet<DocumentGridModelDB> DesignDocumentsGrids { get; set; }

        /// <summary>
        /// Связи полей документов с типами вещественных данных
        /// </summary>
        public DbSet<DocumentPropertyLinkModelDB> DocumentsPropertiesLinks { get; set; }
        /// <summary>
        /// Поля документов (тело документа)
        /// </summary>
        public DbSet<DocumentPropertyMainBodyModelDB> DesignDocumentsMainBodyProperties { get; set; }
        /// <summary>
        /// Поля документов (табличная часть документа)
        /// </summary>
        public DbSet<DocumentPropertyMainGridModelDB> DesignDocumentsMainGridProperties { get; set; }

        /// <summary>
        /// Лог изменений
        /// </summary>
        public DbSet<LogChangeModelDB> ChangeLogs { get; set; }
    }
}
