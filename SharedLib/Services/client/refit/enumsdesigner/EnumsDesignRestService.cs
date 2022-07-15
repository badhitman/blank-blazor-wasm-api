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
    public class EnumsDesignRestService : IEnumsDesignRestService
    {
        private readonly IEnumsDesignRefitService _enums_service;
        private readonly ILogger<EnumsDesignRestService> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public EnumsDesignRestService(IEnumsDesignRefitService set_enums_service, ILogger<EnumsDesignRestService> set_logger)
        {
            _enums_service = set_enums_service;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<GetSimpleResponsePaginationModel> GetMyProjectsEnumsAsync(PaginationRequestModel pagination)
        {
            GetSimpleResponsePaginationModel result = new GetSimpleResponsePaginationModel();

            try
            {
                ApiResponse<GetSimpleResponsePaginationModel> rest = await _enums_service.GetMyProjectsEnumsAsync(pagination);

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
                result.Message = $"Exception {nameof(_enums_service.GetMyProjectsEnumsAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<EnumDesignResponseModel> GetEnumAsync(int id)
        {
            EnumDesignResponseModel result = new EnumDesignResponseModel();

            try
            {
                ApiResponse<EnumDesignResponseModel> rest = await _enums_service.GetEnumAsync(id);

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
                result.Message = $"Exception {nameof(_enums_service.GetEnumAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<IdResponseOwnedModel> AddEnumAsync(NameDescriptionSimpleRealTypeModel enum_object)
        {
            IdResponseOwnedModel result = new IdResponseOwnedModel();

            try
            {
                ApiResponse<IdResponseOwnedModel> rest = await _enums_service.AddEnumAsync(enum_object);

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
                result.Message = $"Exception {nameof(_enums_service.AddEnumAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseCurrentProjectModel> UpdateEnumAsync(IdNameDescriptionSimpleRealTypeModel enum_obj)
        {
            ResponseBaseCurrentProjectModel result = new ResponseBaseCurrentProjectModel();

            try
            {
                ApiResponse<ResponseBaseCurrentProjectModel> rest = await _enums_service.UpdateEnumAsync(enum_obj);

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
                result.Message = $"Exception {nameof(_enums_service.UpdateEnumAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> SetToggleDeleteEnumAsync(int id)
        {
            ResponseBaseModel result = new ResponseBaseModel();

            try
            {
                ApiResponse<ResponseBaseModel> rest = await _enums_service.SetToggleDeleteEnumAsync(id);

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
                result.Message = $"Exception {nameof(_enums_service.SetToggleDeleteEnumAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseModel> ConfirmDeleteEnumAsync(ConfirmActionByNameModel confirm_delete)
        {
            ResponseBaseModel result = new ResponseBaseModel();

            try
            {
                ApiResponse<ResponseBaseModel> rest = await _enums_service.ConfirmDeleteEnumAsync(confirm_delete);

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
                result.Message = $"Exception {nameof(_enums_service.ConfirmDeleteEnumAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> EnumItemUpdateAsync(IdNameDescriptionSimpleModel action)
        {
            GetEnumItemsResponseModel result = new GetEnumItemsResponseModel();

            try
            {
                ApiResponse<GetEnumItemsResponseModel> rest = await _enums_service.EnumItemUpdateAsync(action);

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
                result.Message = $"Exception {nameof(_enums_service.EnumItemUpdateAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> CreateEnumItemElementAsync(EnumItemActionRequestModel action)
        {
            GetEnumItemsResponseModel result = new GetEnumItemsResponseModel();

            try
            {
                ApiResponse<GetEnumItemsResponseModel> rest = await _enums_service.CreateEnumItemElementAsync(action);

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
                result.Message = $"Exception {nameof(_enums_service.CreateEnumItemElementAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> MoveUpAsync(int id)
        {
            GetEnumItemsResponseModel result = new GetEnumItemsResponseModel();

            try
            {
                ApiResponse<GetEnumItemsResponseModel> rest = await _enums_service.MoveUpAsync(id);

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
                result.Message = $"Exception {nameof(_enums_service.MoveUpAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> MoveDownAsync(int id)
        {
            GetEnumItemsResponseModel result = new GetEnumItemsResponseModel();

            try
            {
                ApiResponse<GetEnumItemsResponseModel> rest = await _enums_service.MoveDownAsync(id);

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
                result.Message = $"Exception {nameof(_enums_service.MoveDownAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> DeleteMarkToggleAsync(int id)
        {
            GetEnumItemsResponseModel result = new GetEnumItemsResponseModel();

            try
            {
                ApiResponse<GetEnumItemsResponseModel> rest = await _enums_service.DeleteMarkToggleAsync(id);

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
                result.Message = $"Exception {nameof(_enums_service.DeleteMarkToggleAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GetEnumItemsResponseModel> TrashElementAsync(int id)
        {
            GetEnumItemsResponseModel result = new GetEnumItemsResponseModel();

            try
            {
                ApiResponse<GetEnumItemsResponseModel> rest = await _enums_service.TrashElementAsync(id);

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
                result.Message = $"Exception {nameof(_enums_service.TrashElementAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}