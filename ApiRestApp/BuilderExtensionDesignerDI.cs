﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using DbTablesLib;
using ServerLib;

namespace SharedLib
{
    public static class BuilderExtensionDesignerDI
    {
        public static void BuildDesigner(this IServiceCollection services)
        {
            services.AddScoped<IProjectsTable, ProjectsTable>();
            services.AddScoped<ILinksProjectsTable, LinksProjectsTable>();
            services.AddScoped<IDesignerEnumsTable, DesignerEnumsTable>();
            services.AddScoped<IDesignerDocumensTable, DesignerDocumentsTable>();
            services.AddScoped<IDesignerItemsEnumsTable, DesignerItemsEnumsTable>();
            services.AddScoped<IDesignerDocumensMainBodyPropertiesTable, DesignerDocumentsMainBodyPropertiesTable>();
            services.AddScoped<IDesignerDocumensGridPropertiesTable, DesignerDocumentsGridPropertiesTable>();
            services.AddScoped<IDesignerUniversalTable, DesignerUniversalTable>();
            services.AddScoped<ILogChangeTable, LogChangeTable>(); 

            services.AddScoped<IProjectsService, ProjectsService>();
            services.AddScoped<ILinksUsersProjectsService, LinksUsersPrjectsService>();
            services.AddScoped<IDesignerEnumsService, DesignerEnumsService>();
            services.AddScoped<IDesignerDocumentsService, DesignerDocumentsService>();
            services.AddScoped<IDesignerDocumentsPropertiesMainBodyService, DesignerDocumentsPropertiesMainBodyService>();
            services.AddScoped<IDesignerDocumentsGridPropertiesService, DesignerDocumentsGridPropertiesService>();
            services.AddScoped<IDesignerSharedService, DesignerSharedService>();
            services.AddScoped<IDesignerStructureService, DesignerStructureService>();
            services.AddScoped<ILogsChangesService, LogsChangesService>();
        }
    }
}
