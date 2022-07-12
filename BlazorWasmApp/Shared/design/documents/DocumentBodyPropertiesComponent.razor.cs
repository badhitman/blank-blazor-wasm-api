////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Components;
using SharedLib.Models;

namespace BlazorWasmApp.Shared.design.documents
{
    public partial class DocumentBodyPropertiesComponent
    {
        [Parameter, EditorRequired]
        public AreasPropertiesEnum AreaProperty { get; set; }

        [Parameter, EditorRequired]
        public int? DocumentId { get; set; }

        [Parameter, EditorRequired]
        public IEnumerable<SimplePropertyRealTypeModel> DataRows { get; set; }

        /// <summary>
        /// Перечисления проекта
        /// </summary>
        [Parameter, EditorRequired]
        public IEnumerable<RealTypeLiteModel> EnumsTypesOfProject { get; set; }

        /// <summary>
        /// Документы проекта
        /// </summary>
        [Parameter, EditorRequired]
        public IEnumerable<RealTypeLiteModel> DocumentsTypesOfProject { get; set; }

        PropertyEditRealTypeModel CurrentProperty;

        private ModalWindowComponent Modal { get; set; }
        private string ModalBodyText { get; set; } = string.Empty;

        bool IsDisabledDownButton(SimplePropertyRealTypeModel prop)
        {
            int index_element = DataRows.ToList().FindIndex(x => x.Id == prop.Id);
            bool res = index_element + 1 == DataRows.Count();
            return res;
        }

        bool IsDisabledUpButton(SimplePropertyRealTypeModel prop)
        {
            int index_element = DataRows.ToList().FindIndex(x => x.Id == prop.Id);
            bool res = index_element == 0;
            return res;
        }

        void SetCurrentProperty(PropertyEditRealTypeModel prop)
        {
            prop.GenerateSelectedTypeTemplate();
            CurrentProperty = prop;
        }

        /// <summary>
        /// Сдвинуть поле документа (выше или ниже)
        /// </summary>
        /// <param name="property_id">Идентификатор поля документа</param>
        /// <param name="direction">Направление сдвига (вверх или вниз)</param>
        async Task MovePropertyAsync(int property_id, DesignObjectsItemsActionsEnum direction)
        {
            _logger.LogInformation(direction.ToString());
            GetPropertiesSimpleRealTypeResponseModel rest = null;
            switch (direction)
            {
                case DesignObjectsItemsActionsEnum.MoveDownAction:
                    rest = AreaProperty switch
                    {
                        AreasPropertiesEnum.Body => await _documents_properties_main_body_refit_service.MoveDownAsync(property_id),
                        AreasPropertiesEnum.Table => await _documents_properties_main_grid_refit_service.MoveDownAsync(property_id)
                    };
                    break;
                case DesignObjectsItemsActionsEnum.MoveUpAction:
                    rest = AreaProperty switch
                    {
                        AreasPropertiesEnum.Body => await _documents_properties_main_body_refit_service.MoveUpAsync(property_id),
                        AreasPropertiesEnum.Table => await _documents_properties_main_grid_refit_service.MoveUpAsync(property_id)
                    };
                    break;
            }
            if (!rest.IsSuccess)
            {
                if (!string.IsNullOrEmpty(rest.Message))
                {
                    _logger.LogError(rest.Message);
                    ModalBodyText = rest.Message;
                    Modal.Open("Ошибка!");
                }
                else
                {
                    ModalBodyText = "Ошибка API: MoveUp/MoveDown";
                    _logger.LogError(ModalBodyText);
                    Modal.Open("Ошибка!");
                }
            }
            else
            {
                DataRows = rest.DataRows;
            }
        }

        void UpdateDelegate(IEnumerable<SimplePropertyRealTypeModel> rows)
        {
            DataRows = rows;
            SimplePropertyRealTypeModel? curr = DataRows.FirstOrDefault(x => x.Id == CurrentProperty.Id);
            if (curr is null)
                curr = DataRows.FirstOrDefault();

            SetCurrentProperty(new PropertyEditRealTypeModel(curr is null ? new SimplePropertyRealTypeModel() : curr));

            StateHasChanged();
        }
    }
}