////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Режимы поиска текста
    /// </summary>
    public enum FindTextModesEnum
    {
        /// <summary>
        /// Равен сроке
        /// </summary>
        Equal,

        /// <summary>
        /// Не равен строке
        /// </summary>
        NotEqual,

        /// <summary>
        /// Содержит подстроку в строке
        /// </summary>
        Contains,

        /// <summary>
        /// Не содержит подстроку в строке
        /// </summary>
        NotContains
    }
}
