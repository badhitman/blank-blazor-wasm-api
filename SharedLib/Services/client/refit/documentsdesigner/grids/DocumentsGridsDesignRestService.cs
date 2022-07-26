////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.Extensions.Logging;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class DocumentsGridsDesignRestService : IDocumentsGridsDesignRestService
    {
        private readonly IDocumentsGridsDesignRefitService _documents_service;
        private readonly ILogger<DocumentsGridsDesignRestService> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DocumentsGridsDesignRestService(IDocumentsGridsDesignRefitService set_documents_service, ILogger<DocumentsGridsDesignRestService> set_logger)
        {
            _documents_service = set_documents_service;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<RealTypeRowsResponseModel> GetGridsAsync(int document_id)
        {
            RealTypeRowsResponseModel result = new();

            try
            {
                ApiResponse<RealTypeRowsResponseModel> rest = await _documents_service.GetGridsAsync(document_id);

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
                result.Message = $"Exception {nameof(_documents_service.GetGridsAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RealTypeRowsResponseModel> AddGridAsync(SystemDocumentsNamedSimpleModel grid_for_document_object)
        {
            RealTypeRowsResponseModel result = new();

            try
            {
                ApiResponse<RealTypeRowsResponseModel> rest = await _documents_service.AddGridAsync(grid_for_document_object);

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
                result.Message = $"Exception {nameof(_documents_service.AddGridAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RealTypeRowsResponseModel> UpdateGridAsync(RealTypeModel grid_for_document_obj)
        {
            RealTypeRowsResponseModel result = new();

            try
            {
                ApiResponse<RealTypeRowsResponseModel> rest = await _documents_service.UpdateGridAsync(grid_for_document_obj);

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
                result.Message = $"Exception {nameof(_documents_service.UpdateGridAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RealTypeRowsResponseModel> SetToggleDeleteGridAsync(int id)
        {
            RealTypeRowsResponseModel result = new();

            try
            {
                ApiResponse<RealTypeRowsResponseModel> rest = await _documents_service.SetToggleDeleteGridAsync(id);

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
                result.Message = $"Exception {nameof(_documents_service.SetToggleDeleteGridAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<RealTypeRowsResponseModel> RemoveGridAsync(int id)
        {
            RealTypeRowsResponseModel result = new();

            try
            {
                ApiResponse<RealTypeRowsResponseModel> rest = await _documents_service.RemoveGridAsync(id);

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
                result.Message = $"Exception {nameof(_documents_service.RemoveGridAsync)}";
                _logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}