////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Newtonsoft.Json;

namespace reCaptcha.Models.VerifyingUsersResponse
{
    /// <summary>
    /// Ответ/результат проверки reCaptcha
    /// </summary>
    public class ReCaptcha2ResponseModel : Abstract_reCaptchaResponseModel
    {
        /// <summary>
        /// имя хоста сайта, на котором была решена рекапча
        /// </summary>
        [JsonProperty("hostname")]
        public string? Hostname { get; set; }

        /// <summary>
        /// Конвертировать в строковое представление
        /// </summary>
        /// <returns>Строковое представление</returns>
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "Hostname:" + Hostname;
        }
    }
}
