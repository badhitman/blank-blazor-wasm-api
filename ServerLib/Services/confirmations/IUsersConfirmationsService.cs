////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace ServerLib
{
    /// <summary>
    /// Сервис работы с подвтерждениями действий пользователя
    /// </summary>
    public interface IUsersConfirmationsService
    {
        /// <summary>
        /// Подтвердить действие пользователя
        /// </summary>
        /// <param name="confirm_id">ИД подтверждения</param>
        public Task<ResponseBaseModel?> ConfirmActionAsync(string confirm_id);

        /// <summary>
        /// Получить пдвтерждение пользователя по идентефикатору из БД
        /// </summary>
        /// <param name="confirm_id">Идентификатор подвтерждения пользователя</param>
        /// <param name="include_user_data">Признак необходимости загрузки связанных данных к объекту БД</param>
        /// <returns>Объект подвтерждения действия пользователя (результат запроса)</returns>
        public Task<ConfirmationResponseModel> GetConfirmationAsync(string confirm_id, bool include_user_data = true);

        /// <summary>
        /// Создать пдвтерждение пользователя в БД
        /// </summary>
        /// <param name="user">Пользователь, который подтверждает действие</param>
        /// <param name="ConfirmationType">Тип подвтерждения действия пользователя</param>
        /// <param name="send_email">Отправить уведомление о создании временной ссылки подвтерждения дейтсвия пользователя</param>
        /// <returns>Объект подвтерждения действия пользователя (результат запроса)</returns>
        public Task<ConfirmationResponseModel> CreateConfirmationAsync(UserModelDB user, ConfirmationsTypesEnum ConfirmationType, bool send_email = true);
    }
}
