////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Объект подвтерждения действия пользователя (результат запроса)
    /// </summary>
    public class ConfirmationResponseModel : ResponseBaseModel
    {
        /// <summary>
        /// Объект подвтерждения действия пользователя
        /// </summary>
        public ConfirmationUserActionModelDb? Confirmation { get; set; }
    }
}
