////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib
{
    /// <summary>
    /// Blazor reCaptcha component
    /// </summary>
    public abstract class BlazorReCaptchaComponentBaseModel : BlazorBusyComponentBaseModel
    {
        /// <summary>
        /// Событие просрочки проврки reCaptcha
        /// </summary>
        public abstract void OnReCaptchaExpired();

        /// <summary>
        /// Событие успешной проверки reCaptcha
        /// </summary>
        /// <param name="response_code"></param>
        public abstract void OnReCaptchaSuccess(string response_code);

        /// <summary>
        /// Событие неудачной проверки reCaptcha
        /// </summary>
        /// <param name="response_code"></param>
        public abstract void OnReCaptchaFailure(string response_code);
    }
}
