////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Newtonsoft.Json;

namespace reCaptcha.Models.VerifyingUsersResponse
{
    /// <summary>
    /// Ответ проверки reCaptcha3
    /// </summary>
    public class ReCaptcha3ResponseModel : ReCaptcha2ResponseModel
    {
        /// <summary>
        /// имя действия для этого запроса (важно проверить)
        /// </summary>
        [JsonProperty("action")]
        public string? Action { get; set; }

        /// <summary>
        /// оценка для этого запроса (0.0 - 1.0)
        /// </summary>
        [JsonProperty("score")]
        public ushort Score { get; set; }

        /// <summary>
        /// Преобразовать в строку
        /// </summary>
        /// <returns>Строковое представление</returns>
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + "Action: " + Action + Environment.NewLine + "Score: " + Score;
        }
    }
}
