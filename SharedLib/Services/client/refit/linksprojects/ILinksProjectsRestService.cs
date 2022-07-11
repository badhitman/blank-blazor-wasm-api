////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib.Services
{
    /// <summary>
    /// REST служба раоты с API ссылок на проекты
    /// </summary>
    public interface ILinksProjectsRestService
    {
        public Task<GetLinksProjectsResponseModel> GetLinksUsersByProject(int project_id);

        public Task<ResponseBaseModel> DeleteToggleLinkProject(int link_id);

        public Task<ResponseBaseModel> UtdateLevelLinkProjectAsync(UpdateLinkProjectModel set_level_for_link);

        public Task<AddLinkProjectResultModel> AddLinkProject(AddLinkProjectModel new_link_project);
    }
}