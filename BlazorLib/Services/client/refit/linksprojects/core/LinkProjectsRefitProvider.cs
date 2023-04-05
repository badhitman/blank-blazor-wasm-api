////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.Extensions.Logging;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class LinksProjectsRefitProvider : ILinksProjectsRefitProvider
    {
        private readonly ILinksProjectsRefitService _api;
        private readonly ILogger<LinksProjectsRefitProvider> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="set_api"></param>
        /// <param name="set_logger"></param>
        public LinksProjectsRefitProvider(ILinksProjectsRefitService set_api, ILogger<LinksProjectsRefitProvider> set_logger)
        {
            _api = set_api;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetLinksProjectsResponseModel>> GetLinksUsersByProject(int project_id)
        {
            return await _api.GetLinksUsersByProject(project_id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ResponseBaseModel>> DeleteToggleLinkProject(int link_id)
        {
            return await _api.DeleteToggleLinkProject(link_id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ResponseBaseModel>> UtdateLevelLinkProjectAsync(UpdateLinkProjectModel set_level_for_link)
        {
            return await _api.UtdateLevelLinkProjectAsync(set_level_for_link);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<AddLinkProjectResultModel>> AddLinkProject(AddLinkProjectModel new_link_project)
        {
            return await _api.AddLinkProject(new_link_project);
        }
    }
}