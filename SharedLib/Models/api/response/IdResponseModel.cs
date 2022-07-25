////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Результат создания объекта
    /// </summary>
    public class IdResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Конструтктор
        /// </summary>
        /// <param name="responseBaseModel">Объект инициализации</param>
        public IdResponseModel(ResponseBaseModel responseBaseModel)
        {
            IsSuccess = responseBaseModel.IsSuccess;
            Message = responseBaseModel.Message;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public IdResponseModel() { }

        /// <summary>
        /// Идентификатор созданного объекта
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Набор данных IdNameDescriptionSimpleRealTypeModel
    /// </summary>
    public class RealTypeRowsResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Строки данных
        /// </summary>
        public IEnumerable<RealTypeModel> Rows { get; set; }
    }
}