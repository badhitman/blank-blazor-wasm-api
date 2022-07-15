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
    public class DocumentsPropertiesMainBodyDesignRestService : IDocumentsPropertiesMainBodyDesignRestService
    {
        private readonly IDocumentsPropertiesMainBodyDesignRefitService _documents_service;
        private readonly ILogger<DocumentsPropertiesMainBodyDesignRestService> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DocumentsPropertiesMainBodyDesignRestService(IDocumentsPropertiesMainBodyDesignRefitService set_documents_service, ILogger<DocumentsPropertiesMainBodyDesignRestService> set_logger)
        {
            _documents_service = set_documents_service;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<GetDocumentDataResponseModel> GetPropertiesAsync(int document_id)
        {
            GetDocumentDataResponseModel result = new();

            try
            {
                ApiResponse<GetDocumentDataResponseModel> rest = await _documents_service.GetPropertiesAsync(document_id);

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
                result.Message = $"Exception {nameof(_documents_service.GetPropertiesAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GetPropertiesSimpleRealTypeResponseModel> AddPropertyAsync(PropertySimpleRealTypeModel property_for_document_object)
        {
            GetPropertiesSimpleRealTypeResponseModel result = new();

            try
            {
                ApiResponse<GetPropertiesSimpleRealTypeResponseModel> rest = await _documents_service.AddPropertyAsync(property_for_document_object);

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
                result.Message = $"Exception {nameof(_documents_service.AddPropertyAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GetPropertiesSimpleRealTypeResponseModel> SetToggleDeletePropertyAsync(int id)
        {
            GetPropertiesSimpleRealTypeResponseModel result = new();

            try
            {
                ApiResponse<GetPropertiesSimpleRealTypeResponseModel> rest = await _documents_service.SetToggleDeletePropertyAsync(id);

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
                result.Message = $"Exception {nameof(_documents_service.SetToggleDeletePropertyAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GetPropertiesSimpleRealTypeResponseModel> UpdatePropertyAsync(PropertyOfDocumentModel property_for_document_obj)
        {
            GetPropertiesSimpleRealTypeResponseModel result = new();

            try
            {
                ApiResponse<GetPropertiesSimpleRealTypeResponseModel> rest = await _documents_service.UpdatePropertyAsync(property_for_document_obj);

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
                result.Message = $"Exception {nameof(_documents_service.UpdatePropertyAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GetPropertiesSimpleRealTypeResponseModel> MoveUpAsync(int id)
        {
            GetPropertiesSimpleRealTypeResponseModel result = new();

            try
            {
                ApiResponse<GetPropertiesSimpleRealTypeResponseModel> rest = await _documents_service.MoveUpAsync(id);

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
                result.Message = $"Exception {nameof(_documents_service.MoveUpAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GetPropertiesSimpleRealTypeResponseModel> MoveDownAsync(int id)
        {
            GetPropertiesSimpleRealTypeResponseModel result = new();

            try
            {
                ApiResponse<GetPropertiesSimpleRealTypeResponseModel> rest = await _documents_service.MoveDownAsync(id);

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
                result.Message = $"Exception {nameof(_documents_service.MoveDownAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<GetPropertiesSimpleRealTypeResponseModel> TrashPropertyAsync(int id)
        {
            GetPropertiesSimpleRealTypeResponseModel result = new();

            try
            {
                ApiResponse<GetPropertiesSimpleRealTypeResponseModel> rest = await _documents_service.TrashPropertyAsync(id);

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
                result.Message = $"Exception {nameof(_documents_service.TrashPropertyAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}