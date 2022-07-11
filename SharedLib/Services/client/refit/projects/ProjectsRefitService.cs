﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Services;
using Microsoft.Extensions.Logging;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class ProjectsRefitService : IProjectsRestService
    {
        private readonly IProjectsRefitService _users_projects_service;
        private readonly ILogger<ProjectsRefitService> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="set_users_projects_service"></param>
        /// <param name="set_logger"></param>
        public ProjectsRefitService(IProjectsRefitService set_users_projects_service, ILogger<ProjectsRefitService> set_logger)
        {
            _users_projects_service = set_users_projects_service;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<GetUsersProjectsResponsePaginationModel> GetMyProjectsAsync(PaginationRequestModel pagination)
        {
            GetUsersProjectsResponsePaginationModel result = new GetUsersProjectsResponsePaginationModel();

            try
            {
                ApiResponse<GetUsersProjectsResponsePaginationModel> rest = await _users_projects_service.GetMyProjectsAsync(pagination);

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
                result.Message = $"Exception {nameof(_users_projects_service.GetMyProjectsAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<UserProjectResponseModel> GetProjectAsync(int id)
        {
            UserProjectResponseModel result = new UserProjectResponseModel();

            try
            {
                ApiResponse<UserProjectResponseModel> rest = await _users_projects_service.GetProjectAsync(id);

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
                result.Message = $"Exception {nameof(_users_projects_service.GetProjectAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> SetCurrentProjectForUserAsync(int project_id)
        {
            ResponseBaseModel result = new ResponseBaseModel();

            try
            {
                ApiResponse<ResponseBaseModel> rest = await _users_projects_service.SetCurrentProjectForUserAsync(project_id);

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
                result.Message = $"Exception {nameof(_users_projects_service.SetCurrentProjectForUserAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<IdResponseModel> AddProjectAsync(NameDescriptionSimpleModel project)
        {
            IdResponseModel result = new IdResponseModel();

            try
            {
                ApiResponse<IdResponseModel> rest = await _users_projects_service.AddProjectAsync(project);

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
                result.Message = $"Exception {nameof(_users_projects_service.AddProjectAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> UpdateProjectAsync(IdNameDescriptionSimpleModel project)
        {
            ResponseBaseModel result = new ResponseBaseModel();

            try
            {
                ApiResponse<ResponseBaseModel> rest = await _users_projects_service.UpdateProjectAsync(project);

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
                result.Message = $"Exception {nameof(_users_projects_service.UpdateProjectAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }


        /// <inheritdoc/>
        public async Task<ResponseBaseModel> SetDeleteProjectAsync(int project_id)
        {
            ResponseBaseModel result = new ResponseBaseModel();

            try
            {
                ApiResponse<ResponseBaseModel> rest = await _users_projects_service.SetDeleteProjectAsync(project_id);

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
                result.Message = $"Exception {nameof(_users_projects_service.SetDeleteProjectAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<ProjectStructureResponseModel> GetStructureProject(int project_id)
        {
            ProjectStructureResponseModel result = new ProjectStructureResponseModel();

            try
            {
                ApiResponse<ProjectStructureResponseModel> rest = await _users_projects_service.GetStructureProject(project_id);

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
                result.Message = $"Exception {nameof(_users_projects_service.GetStructureProject)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}