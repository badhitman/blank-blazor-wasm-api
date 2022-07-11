////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.Extensions.Logging;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class DocumentsDesignRefitProvider : IDocumentsDesignRefitProvider
    {
        private readonly IDocumentsDesignRefitService _api;
        private readonly ILogger<DocumentsDesignRefitProvider> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DocumentsDesignRefitProvider(IDocumentsDesignRefitService set_api, ILogger<DocumentsDesignRefitProvider> set_logger)
        {
            _api = set_api;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetSimpleResponsePaginationModel>> GetDocumentsFromMyCurrentProjectAsync(PaginationRequestModel pagination)
        {
            return await _api.GetDocumentsFromMyCurrentProjectAsync(pagination);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<DocumentDesignResponseModel>> GetDocumentAsync(int id)
        {
            return await _api.GetDocumentAsync(id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<IdResponseOwnedModel>> AddDocumentAsync(NameDescriptionSimpleRealTypeModel document_object)
        {
            return await _api.AddDocumentAsync(document_object);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ResponseBaseCurrentProjectModel>> UpdateDocumentAsync(IdNameDescriptionSimpleRealTypeModel document_obj)
        {
            return await _api.UpdateDocumentAsync(document_obj);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<ResponseBaseModel>> SetToggleDeleteDocumentAsync(int id)
        {
            return await _api.SetToggleDeleteDocumentAsync(id);
        }
    }
}