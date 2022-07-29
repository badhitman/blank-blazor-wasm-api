////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Components;
using SharedLib.Models;
using System.Text.RegularExpressions;

namespace BlazorWasmApp.Shared.design.documents
{
    public partial class DocumentPropertiesComponent
    {
        [Parameter, EditorRequired]
        public int Id { get; set; }

        /// <summary>
        /// Расположения/размещения свойств: тело документа или табличная часть документа
        /// </summary>
        [Parameter, EditorRequired]
        public AreasPropertiesEnum AreaProperty { get; set; }

        PropertyCreateRealTypeModel new_property_body_item_element { get; set; } = new PropertyCreateRealTypeModel();

        private ModalWindowComponent Modal { get; set; }
        private string ModalBodyText { get; set; } = string.Empty;

        IEnumerable<RealTypeModel> Grids = Enumerable.Empty<RealTypeModel>();

        int _selected_grid_id = 0;
        int selected_grid_id
        {
            get
            {
                return _selected_grid_id;
            }
            set
            {
                _selected_grid_id = value;
                if (_selected_grid_id > 0)
                    ReloadForm(_selected_grid_id);
            }
        }

        /// <summary>
        /// Данные
        /// </summary>
        public IEnumerable<SimplePropertyRealTypeModel> DataRows { get; set; } = Enumerable.Empty<SimplePropertyRealTypeModel>();

        /// <summary>
        /// Перечисления проекта
        /// </summary>
        public IEnumerable<RealTypeLiteModel> EnumsTypesOfProject { get; set; }

        /// <summary>
        /// Документы проекта
        /// </summary>
        public IEnumerable<RealTypeLiteModel> DocumentsTypesOfProject { get; set; }

        protected override async void OnInitialized()
        {
            if (Id == 0)
            {
                return;
            }

            if (AreaProperty == AreasPropertiesEnum.Table)
            {
                await GetGridsAsync(Id);
            }
            else
            {
                await ReloadForm(Id);
            }
        }

        async Task GetGridsAsync(int id)
        {
            if (id <= 0)
            {
                ModalBodyText = "Идентификатор документа не может быть 0";
                _logger.LogError(ModalBodyText);
                Modal.Open("Ошибка!");
                return;
            }
            
            RealTypeRowsResponseModel rest = await _documents_grids_design_refit_service.GetGridsAsync(id);
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
                    ModalBodyText = $"Ошибка API: {nameof(_documents_grids_design_refit_service.GetGridsAsync)}";
                    _logger.LogError(ModalBodyText);
                    Modal.Open("Ошибка!");
                }
            }
            else
            {
                Grids = rest.Rows;
                if (Grids.Any())
                {
                    _selected_grid_id = Grids.First().Id;
                }
            }
            if (_selected_grid_id > 0)
                await ReloadForm(_selected_grid_id);
        }

        async Task ReloadForm(int id)
        {
            if (id <= 0)
            {
                ModalBodyText = "Идентификатор не может быть 0";
                _logger.LogError(ModalBodyText);
                Modal.Open("Ошибка!");
                return;
            }

            IsBusyProgress = true;
            GetDocumentDataResponseModel rest = AreaProperty switch
            {
                AreasPropertiesEnum.Body => await _documents_properties_body_refit_service.GetPropertiesAsync(id),
                AreasPropertiesEnum.Table => await _documents_grid_properties_refit_service.GetPropertiesAsync(_selected_grid_id)
            };

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
                    ModalBodyText = $"Ошибка API: {nameof(_documents_properties_body_refit_service.GetPropertiesAsync)}";
                    _logger.LogError(ModalBodyText);
                    Modal.Open("Ошибка!");
                }
            }
            else
            {
                DataRows = rest.DataRows;
                EnumsTypesOfProject = rest.EnumsTypesOfProject;
                DocumentsTypesOfProject = rest.DocumentsTypesOfProject.Select(x => { if (x.Id == Id) { x.IsDeleted = true; } return x; });
            }
            IsBusyProgress = false;
            StateHasChanged();
        }

        /// <summary>
        /// Создать/добавить поле основного тела документа
        /// </summary>
        async Task HandleSubmitAddingPropertyAsync()
        {
            if (Id <= 0)
            {
                return;
            }
            if (!Regex.IsMatch(new_property_body_item_element.SystemCodeName, GlobalStaticConstants.SYSTEM_CODE_NAME_TEMPLATE))
            {
                ModalBodyText = $"Системное кодовое имя должно состоять из букв латинского алфавита не менее трёх символов.";
                Modal.Open("Ошибка!");
                return;
            }
            if (!new_property_body_item_element.PropertyType.HasValue)
            {
                ModalBodyText = $"Укажите тип реквизита";
                Modal.Open("Ошибка!");
                return;
            }
            if (string.IsNullOrWhiteSpace(new_property_body_item_element.Name) || new_property_body_item_element.Name.Trim().Length < 3)
            {
                ModalBodyText = $"Наименование реквизита должно иметь минимум 3 символа";
                Modal.Open("Ошибка!");
                return;
            }

            PropertySimpleRealTypeModel obj = (PropertySimpleRealTypeModel)new_property_body_item_element;
            if (AreaProperty == AreasPropertiesEnum.Body)
                obj.OwnerId = Id;
            else
                obj.OwnerId = _selected_grid_id;

            obj.DocumentPropertyLink = new_property_body_item_element.DocumentPropertyLink;

            GetPropertiesSimpleRealTypeResponseModel rest = AreaProperty switch
            {
                AreasPropertiesEnum.Body => await _documents_properties_body_refit_service.AddPropertyAsync(obj),
                AreasPropertiesEnum.Table => await _documents_grid_properties_refit_service.AddPropertyAsync(obj)
            };

            if (!rest.IsSuccess)
            {
                ModalBodyText = rest.Message;
                Modal.Open("Ошибка!");
                return;
            }
            DataRows = rest.DataRows;
            new_property_body_item_element.Reset();
            StateHasChanged();
        }
    }
}