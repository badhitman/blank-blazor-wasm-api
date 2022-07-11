////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Newtonsoft.Json;

namespace SharedLib.Models
{
    /// <summary>
    /// Базовая модель ответа сервера rest/api
    /// </summary>
    public class ResponseBaseModel
    {
        /// <summary>
        /// Результат обработки запроса.
        /// True - если удачно бз ошибок. False  - если возникли ошибки
        /// </summary>
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Сообщение сервера. Если IsSuccess == false, то будет сообщение об ошибке
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;
    }
}