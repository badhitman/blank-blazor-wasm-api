////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// Refit коннектор к API/LinksProjects
    /// </summary>
    [Headers("Content-Type: application/json")]
    public interface ILinksProjectsRefitService
    {
        [Get("/api/linksprojects")]
        public Task<ApiResponse<GetLinksProjectsResponseModel>> GetLinksUsersByProject(int project_id);

        [Delete("/api/linksprojects")]
        public Task<ApiResponse<ResponseBaseModel>> DeleteToggleLinkProject(int link_id);

        [Put("/api/linksprojects")]
        public Task<ApiResponse<ResponseBaseModel>> UtdateLevelLinkProjectAsync(UpdateLinkProjectModel set_level_for_link);

        [Post("/api/linksprojects")]
        public Task<ApiResponse<AddLinkProjectResultModel>> AddLinkProject(AddLinkProjectModel new_link_project);
    }
}