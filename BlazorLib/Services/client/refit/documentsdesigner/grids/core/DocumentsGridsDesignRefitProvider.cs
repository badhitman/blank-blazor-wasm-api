////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.Extensions.Logging;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class DocumentsGridsDesignRefitProvider : IDocumentsGridsDesignRefitProvider
    {
        private readonly IDocumentsGridsDesignRefitService _api;
        private readonly ILogger<DocumentsGridsDesignRefitProvider> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DocumentsGridsDesignRefitProvider(IDocumentsGridsDesignRefitService set_api, ILogger<DocumentsGridsDesignRefitProvider> set_logger)
        {
            _api = set_api;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<RealTypeRowsResponseModel>> GetGridsAsync(int document_id)
        {
            return await _api.GetGridsAsync(document_id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<RealTypeRowsResponseModel>> AddGridAsync(SystemDocumentsNamedSimpleModel grid_for_document_object)
        {
            return await _api.AddGridAsync(grid_for_document_object);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<RealTypeRowsResponseModel>> UpdateGridAsync(RealTypeModel grid_for_document_obj)
        {
            return await _api.UpdateGridAsync(grid_for_document_obj);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<RealTypeRowsResponseModel>> SetToggleDeleteGridAsync(int id)
        {
            return await _api.SetToggleDeleteGridAsync(id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<RealTypeRowsResponseModel>> RemoveGridAsync(int id)
        {
            return await _api.RemoveGridAsync(id);
        }
    }
}