////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;

namespace SharedLib.Models
{
    /// <summary>
    /// Подтверждение намерений/действий пользователя
    /// </summary>
    [Index(nameof(ConfirmationType))]
    [Index(nameof(GuidConfirmation), IsUnique = true)]
    public class ConfirmationUserActionModelDb : EntryCreatedModel
    {
        /// <summary>
        /// Уникальный идентификатор маркера подтверждения
        /// </summary>
        public string GuidConfirmation { get; set; } = string.Empty;

        /// <summary>
        /// Идентификатор/ключ (пользователя), который запросил разрешение на действие
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Пользователь, который запросил разрешение на действие
        /// </summary>
        public UserModelDB User { get; set; }

        /// <summary>
        /// Предельный срок (до какого даты/времени) маркер актуален
        /// </summary>
        public DateTime Deadline { get; set; }

        /// <summary>
        /// Тип действия, которое следует подтвердить
        /// </summary>
        public ConfirmationsTypesEnum ConfirmationType { get; set; }

        /// <summary>
        /// Когда был подвтерждён (если был)
        /// </summary>
        public DateTime? ConfirmetAt { get; set; }

        /// <summary>
        /// Если при создании уведомления и последующей отправке произошёл сбой, то он будет записан сюда.
        /// В проивном случае (если ошибок не возникнет) поле будет пустым
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public ConfirmationUserActionModelDb() { }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="user">Пользователь, который создаёт маркер подвтерждения действия</param>
        /// <param name="confirmation_type">Тип действия, которое следует подтвердить</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public ConfirmationUserActionModelDb(UserModelDB user, ConfirmationsTypesEnum confirmation_type)
        {
            GuidConfirmation = Guid.NewGuid().ToString();
            UserId = user.Id;
            User = user;
            ConfirmationType = confirmation_type;
            Name = confirmation_type switch
            {
                ConfirmationsTypesEnum.RegistrationUser => $"Регистрация пользователя [login:'{user.Profile.Login}']",
                ConfirmationsTypesEnum.RestoreUser => $"Сброс пароля [login:'{user.Profile.Login}']",
                _ => throw new ArgumentOutOfRangeException(nameof(confirmation_type), "Тип подвтерждения действия пользователя не определён"),
            };
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="user">Пользователь, который создаёт маркер подвтерждения действия</param>
        /// <param name="confirmation_type">Тип действия, которое следует подтвердить</param>
        /// <param name="deadline">Предельный срок (до какого даты/времени) маркер актуален</param>
        public ConfirmationUserActionModelDb(UserModelDB user, ConfirmationsTypesEnum confirmation_type, DateTime deadline) : this(user, confirmation_type)
        {
            Deadline = deadline;
        }
    }
}