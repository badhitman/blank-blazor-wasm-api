////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.Extensions.Logging;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class ProjectsRefitProvider : IProjectsRefitProvider
    {
        private readonly IProjectsRefitService _api;
        private readonly ILogger<ProjectsRefitProvider> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ProjectsRefitProvider(IProjectsRefitService set_api, ILogger<ProjectsRefitProvider> set_logger)
        {
            _api = set_api;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<UserProjectResponseModel>> GetMyCurrentProjectAsync()
        {
            return await _api.GetMyCurrentProjectAsync();
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetUsersProjectsResponsePaginationModel>> GetMyProjectsAsync(PaginationRequestModel pagination)
        {
            return await _api.GetMyProjectsAsync(pagination);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<UserProjectResponseModel>> GetProjectAsync(int id)
        {
            return await _api.GetProjectAsync(id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ResponseBaseModel>> SetCurrentProjectForUserAsync(int project_id)
        {
            return await _api.SetCurrentProjectForUserAsync(project_id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<IdResponseModel>> AddProjectAsync(NameDescriptionSimpleModel project)
        {
            return await _api.AddProjectAsync(project);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ResponseBaseModel>> UpdateProjectAsync(IdNameDescriptionSimpleModel project)
        {
            return await _api.UpdateProjectAsync(project);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ResponseBaseModel>> SetDeleteProjectAsync(int project_id)
        {
            return await _api.SetDeleteProjectAsync(project_id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ProjectStructureResponseModel>> GetStructureProject(int project_id)
        {
            return await _api.GetStructureProject(project_id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<LinksRealTypeResponseModel>> GetRealTypeLinks(int owner_id, OwnersLinksTypesEnum owner_type)
        {
            return await _api.GetRealTypeLinks(owner_id, owner_type);
        }
    }
}