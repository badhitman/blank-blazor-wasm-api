////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.Extensions.Logging;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class EnumsDesignRefitProvider : IEnumsDesignRefitProvider
    {
        private readonly IEnumsDesignRefitService _api;
        private readonly ILogger<EnumsDesignRefitProvider> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public EnumsDesignRefitProvider(IEnumsDesignRefitService set_api, ILogger<EnumsDesignRefitProvider> set_logger)
        {
            _api = set_api;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetSimpleResponsePaginationModel>> GetMyProjectsEnumsAsync(PaginationRequestModel pagination)
        {
            return await _api.GetMyProjectsEnumsAsync(pagination);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<EnumDesignResponseModel>> GetEnumAsync(int id)
        {
            return await _api.GetEnumAsync(id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<IdResponseOwnedModel>> AddEnumAsync(NameDescriptionSimpleRealTypeModel enum_object)
        {
            return await _api.AddEnumAsync(enum_object);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ResponseBaseCurrentProjectModel>> UpdateEnumAsync(IdNameDescriptionSimpleRealTypeModel enum_obj)
        {
            return await _api.UpdateEnumAsync(enum_obj);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ResponseBaseModel>> SetToggleDeleteEnumAsync(int id)
        {
            return await _api.SetToggleDeleteEnumAsync(id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ResponseBaseModel>> ConfirmDeleteEnumAsync(ConfirmActionByNameModel confirm_delete)
        {
            return await _api.ConfirmDeleteEnumAsync(confirm_delete);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetEnumItemsResponseModel>> EnumItemUpdateAsync(IdNameDescriptionSimpleModel action)
        {
            return await _api.EnumItemUpdateAsync(action);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetEnumItemsResponseModel>> CreateEnumItemElementAsync(EnumItemActionRequestModel action)
        {
            return await _api.CreateEnumItemElementAsync(action);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetEnumItemsResponseModel>> MoveUpAsync(int id)
        {
            return await _api.MoveUpAsync(id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetEnumItemsResponseModel>> MoveDownAsync(int id)
        {
            return await _api.MoveDownAsync(id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetEnumItemsResponseModel>> DeleteMarkToggleAsync(int id)
        {
            return await _api.DeleteMarkToggleAsync(id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetEnumItemsResponseModel>> TrashElementAsync(int id)
        {
            return await _api.TrashElementAsync(id);
        }
    }
}