////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.Extensions.Logging;
using Refit;
using SharedLib.Models;

namespace SharedLib.Services
{
    /// <inheritdoc/>
    public class DocumentsBodyPropertiesDesignRefitProvider : IDocumentsBodyPropertiesDesignRefitProvider
    {
        private readonly IDocumentsBodyPropertiesDesignRefitService _api;
        private readonly ILogger<DocumentsBodyPropertiesDesignRefitProvider> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        public DocumentsBodyPropertiesDesignRefitProvider(IDocumentsBodyPropertiesDesignRefitService set_api, ILogger<DocumentsBodyPropertiesDesignRefitProvider> set_logger)
        {
            _api = set_api;
            _logger = set_logger;
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetDocumentDataResponseModel>> GetPropertiesAsync(int document_id)
        {
            return await _api.GetPropertiesAsync(document_id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> AddPropertyAsync(PropertySimpleRealTypeModel property_for_document_object)
        {
            return await _api.AddPropertyAsync(property_for_document_object);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> SetToggleDeletePropertyAsync(int id)
        {
            return await _api.SetToggleDeletePropertyAsync(id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> UpdatePropertyAsync(PropertyOfDocumentModel property_for_document_obj)
        {
            return await _api.UpdatePropertyAsync(property_for_document_obj);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> TrashPropertyAsync(int id)
        {
            return await _api.TrashPropertyAsync(id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> MoveUpAsync(int id)
        {
            return await _api.MoveUpAsync(id);
        }

        /// <inheritdoc/>
        public async Task<ApiResponse<GetPropertiesSimpleRealTypeResponseModel>> MoveDownAsync(int id)
        {
            return await _api.MoveDownAsync(id);
        }
    }
}