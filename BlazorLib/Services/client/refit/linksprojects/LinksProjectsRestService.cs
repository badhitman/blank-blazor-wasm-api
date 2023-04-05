////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Services;
using Microsoft.Extensions.Logging;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class LinksProjectsRestService : ILinksProjectsRestService
    {
        private readonly ILinksProjectsRefitService _links_projects_service;
        private readonly ILogger<LinksProjectsRestService> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="set_users_projects_service"></param>
        /// <param name="set_logger"></param>
        public LinksProjectsRestService(ILinksProjectsRefitService set_users_projects_service, ILogger<LinksProjectsRestService> set_logger)
        {
            _links_projects_service = set_users_projects_service;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<GetLinksProjectsResponseModel> GetLinksUsersByProject(int project_id)
        {
            GetLinksProjectsResponseModel result = new();

            try
            {
                ApiResponse<GetLinksProjectsResponseModel> rest = await _links_projects_service.GetLinksUsersByProject(project_id);

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;
                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result.IsSuccess = rest.Content.IsSuccess;
                result = rest.Content;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_links_projects_service.GetLinksUsersByProject)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> DeleteToggleLinkProject(int link_id)
        {
            ResponseBaseModel result = new();

            try
            {
                ApiResponse<ResponseBaseModel> rest = await _links_projects_service.DeleteToggleLinkProject(link_id);

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;
                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result.IsSuccess = rest.Content.IsSuccess;
                result = rest.Content;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_links_projects_service.DeleteToggleLinkProject)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> UtdateLevelLinkProjectAsync(UpdateLinkProjectModel set_level_for_link)
        {
            ResponseBaseModel result = new();

            try
            {
                ApiResponse<ResponseBaseModel> rest = await _links_projects_service.UtdateLevelLinkProjectAsync(set_level_for_link);

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;
                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result.IsSuccess = rest.Content.IsSuccess;
                result = rest.Content;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_links_projects_service.UtdateLevelLinkProjectAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<AddLinkProjectResultModel> AddLinkProject(AddLinkProjectModel new_link_project)
        {
            AddLinkProjectResultModel result = new();

            try
            {
                ApiResponse<AddLinkProjectResultModel> rest = await _links_projects_service.AddLinkProject(new_link_project);

                if (rest.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    result.IsSuccess = false;
                    result.Message = $"HTTP error: [code={rest.StatusCode}] {rest?.Error?.Content}";
                    _logger.LogError(result.Message);

                    return result;
                }
                result.IsSuccess = rest.Content.IsSuccess;
                result = rest.Content;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Message = $"Exception {nameof(_links_projects_service.AddLinkProject)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}