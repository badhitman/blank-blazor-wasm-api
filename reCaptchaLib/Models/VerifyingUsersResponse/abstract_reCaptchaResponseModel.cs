////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Newtonsoft.Json;
using reCaptcha.stat;

namespace reCaptcha.Models.VerifyingUsersResponse
{
    /// <summary>
    /// Абстрактная модель результата проверки reCaptcha
    /// </summary>
    public abstract class Abstract_reCaptchaResponseModel
    {
        /// <summary>
        /// был ли этот запрос действительным маркером reCAPTCHA для вашего сайта
        /// </summary>
        public bool success { get; set; } = false;

        /// <summary>
        /// timestamp загрузки проверки (ISO format yyyy-MM-dd'T'HH:mm:ssZZ)
        /// </summary>
        public DateTime challenge_ts { get; set; }

        /// <summary>
        /// Ошибки (коды ошибок)
        /// </summary>
        [JsonProperty("error-codes")]
        public string[]? ErrorСodes { get; set; }

        /// <summary>
        /// Преобразовать в строковое представление
        /// </summary>
        /// <returns>Строковое представление</returns>
        public override string ToString()
        {
            string ret_val = (success ? "Success" : "Not success") + " - " + challenge_ts.ToString() + Environment.NewLine;
            if (ErrorСodes != null)
                foreach (string s in ErrorСodes)
                    ret_val += "  ERR:" + (ReCaptchaVerifyingErrorCodes.AvailableCodes.ContainsKey(s) ? ReCaptchaVerifyingErrorCodes.AvailableCodes[s] : s);

            return ret_val;
        }
    }
}
