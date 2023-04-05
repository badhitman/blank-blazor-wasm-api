////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Refit;

namespace SharedLib.Services
{
    public interface ILinksProjectsRefitProvider
    {
        public Task<ApiResponse<GetLinksProjectsResponseModel>> GetLinksUsersByProject(int project_id);

        public Task<ApiResponse<ResponseBaseModel>> DeleteToggleLinkProject(int link_id);

        public Task<ApiResponse<ResponseBaseModel>> UtdateLevelLinkProjectAsync(UpdateLinkProjectModel set_level_for_link);

        public Task<ApiResponse<AddLinkProjectResultModel>> AddLinkProject(AddLinkProjectModel new_link_project);
    }
}