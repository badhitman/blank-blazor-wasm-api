////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Режимы работы reCaptcha
    /// </summary>
    public enum ReCaptchaModesEnum
    {
        /// <summary>
        /// Отключено
        /// </summary>
        None = 0,

        /// <summary>
        /// v2
        /// </summary>
        Version2 = 1,

        /// <summary>
        /// v2 Invisible
        /// </summary>
        Version2Invisible = 2,

        /*/// <summary>
        /// v3
        /// </summary>
        Version3 = 4,*/
    }
}
