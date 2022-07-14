﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using DbcLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharedLib;
using SharedLib.Models;

namespace DbTablesLib
{
    /// <inheritdoc/>
    public class DesignerDocumentsTable : IDesignerDocumensTable
    {
        readonly DbAppContext _db_context;
        readonly ILogger<DesignerDocumentsTable> _logger;
        readonly IOptions<ServerConfigModel> _config;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DesignerDocumentsTable(DbAppContext set_db_context, ILogger<DesignerDocumentsTable> set_logger, IOptions<ServerConfigModel> set_config)
        {
            _db_context = set_db_context;
            _logger = set_logger;
            _config = set_config;
        }

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync(Dictionary<string, string?>? cashe_upd = null)
        {
            return await _db_context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<DocumentDesignModelDB?> GetDocumentAsync(int document_id, bool include_users_links_for_project = true)
        {
            IQueryable<DocumentDesignModelDB> query = _db_context.DesignDocuments.AsQueryable();
            if (include_users_links_for_project)
            {
                query = query.Include(x => x.Project).ThenInclude(x => x.UsersLinks);
            }
            else
            {
                query = query.Include(x => x.Project);
            }
            return await query.FirstOrDefaultAsync(x => x.Id == document_id);
        }

        /// <inheritdoc/>
        public async Task<DocumentDesignModelDB> GetDocumentAsync(string document_system_code, int project_id, bool include_users_links_for_project = true)
        {
            IQueryable<DocumentDesignModelDB> query = _db_context.DesignDocuments.AsQueryable();
            if (include_users_links_for_project)
            {
                query = query.Include(x => x.Project).ThenInclude(x => x.UsersLinks);
            }
            else
            {
                query = query.Include(x => x.Project);
            }
            return await query.FirstOrDefaultAsync(x => x.SystemCodeName == document_system_code && x.ProjectId == project_id);
        }

        /// <inheritdoc/>
        public async Task<SimplePaginationResponseModel> GetDocumentsForUserAsync((int user_id, AccessLevelsUsersEnum user_level) user, PaginationRequestModel pagination, int current_project_id)
        {
            SimplePaginationResponseModel res;
            if (pagination is null)
                res = new SimplePaginationResponseModel();
            else
                res = new SimplePaginationResponseModel(pagination);

            if (res.PageSize <= _config.Value.PaginationPageSizeMin)
            {
                _logger.LogError(new ArgumentOutOfRangeException(nameof(res.PageSize)), $"Размер страницы пагинатора ={res.PageSize}. Этот параметр не может быть меньше {_config.Value.PaginationPageSizeMin}");
                res.PageSize = _config.Value.PaginationPageSizeMin;
            }

            if (res.PageNum <= 0)
            {
                res.PageNum = 1;
            }

            IQueryable<DocumentDesignModelDB> query = _db_context.DesignDocuments.Where(x => x.ProjectId == current_project_id)
                .Where(x => user.user_level >= AccessLevelsUsersEnum.Admin || (!x.IsDeleted && !x.Project.IsDeleted));

            res.TotalRowsCount = query.Count();

            switch (res.SortBy)
            {
                case nameof(DocumentDesignModelDB.Name):
                    query = res.SortingDirection == VerticalDirectionsEnum.Up
                        ? query.OrderByDescending(x => x.Name)
                        : query.OrderBy(x => x.Name);
                    break;
                default:
                    query = res.SortingDirection == VerticalDirectionsEnum.Up
                        ? query.OrderByDescending(x => x.Id)
                        : query.OrderBy(x => x.Id);
                    break;
            }

            query = query.Skip((res.PageNum - 1) * res.PageSize).Take(res.PageSize);

            res.RowsData = await query
                .Select(x => new
                {
                    doc = x,
                    count_properties_body = _db_context.DesignDocumentsMainBodyProperties.Count(y => x.Id == y.DocumentOwnerId),
                    count_properties_grid = _db_context.DesignDocumentsMainGridProperties.Count(y => x.Id == y.DocumentOwnerId)
                })
                .Select(x => new SimpleRealTypeModel()
                {
                    Id = x.doc.Id,
                    Name = $"{x.doc.Name} ≡{x.count_properties_body} ⁞{x.count_properties_grid}",
                    Description = x.doc.Description,
                    IsDeleted = x.doc.IsDeleted,
                    SystemCodeName = x.doc.SystemCodeName
                })
                .ToArrayAsync();

            return res;
        }

        /// <inheritdoc/>
        public async Task AddDocumentAsync(DocumentDesignModelDB document_new, bool auto_save = true)
        {
            await _db_context.AddAsync(document_new);
            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateDocumentAsync(DocumentDesignModelDB document_upd, bool auto_save = true)
        {
            _db_context.Update(document_upd);
            if (auto_save)
                await SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<DocumentDesignModelDB?> GetDocumentByPropertyMainBodyAsync(int property_id, bool include_users_links_for_project = true)
        {
            IQueryable<DocumentDesignModelDB>? query = _db_context.DesignDocuments.Where(x => x.PropertiesBody.Any(y => y.Id == property_id && y.DocumentOwnerId == x.Id)).AsQueryable();
            if (include_users_links_for_project)
            {
                query = query.Include(x => x.Project).ThenInclude(x => x.UsersLinks);
            }
            else
            {
                query = query.Include(x => x.Project);
            }
            return query.FirstOrDefault();
        }
    }
}