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
    public class DocumentsDesignRestService : IDocumentsDesignRestService
    {
        private readonly IDocumentsDesignRefitService _documents_service;
        private readonly ILogger<DocumentsDesignRestService> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DocumentsDesignRestService(IDocumentsDesignRefitService set_documents_service, ILogger<DocumentsDesignRestService> set_logger)
        {
            _documents_service = set_documents_service;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<GetSimpleResponsePaginationModel> GetDocumentsFromMyCurrentProjectAsync(PaginationRequestModel pagination)
        {
            GetSimpleResponsePaginationModel result = new();

            try
            {
                ApiResponse<GetSimpleResponsePaginationModel> rest = await _documents_service.GetDocumentsFromMyCurrentProjectAsync(pagination);

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
                result.Message = $"Exception {nameof(_documents_service.GetDocumentsFromMyCurrentProjectAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<DocumentDesignResponseModel> GetDocumentAsync(int id)
        {
            DocumentDesignResponseModel result = new();

            try
            {
                ApiResponse<DocumentDesignResponseModel> rest = await _documents_service.GetDocumentAsync(id);

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
                result.Message = $"Exception {nameof(_documents_service.GetDocumentAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<IdResponseOwnedModel> AddDocumentAsync(NameDescriptionSimpleRealTypeModel document_object)
        {
            IdResponseOwnedModel result = new();

            try
            {
                ApiResponse<IdResponseOwnedModel> rest = await _documents_service.AddDocumentAsync(document_object);

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
                result.Message = $"Exception {nameof(_documents_service.AddDocumentAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<ResponseBaseCurrentProjectModel> UpdateDocumentAsync(IdNameDescriptionSimpleRealTypeModel document_obj)
        {
            ResponseBaseCurrentProjectModel result = new();

            try
            {
                ApiResponse<ResponseBaseCurrentProjectModel> rest = await _documents_service.UpdateDocumentAsync(document_obj);

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
                result.Message = $"Exception {nameof(_documents_service.UpdateDocumentAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<DocumentDesignResponseModel> SetToggleDeleteDocumentAsync(int id)
        {
            DocumentDesignResponseModel result = new();

            try
            {
                ApiResponse<DocumentDesignResponseModel> rest = await _documents_service.SetToggleDeleteDocumentAsync(id);

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
                result.Message = $"Exception {nameof(_documents_service.SetToggleDeleteDocumentAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}