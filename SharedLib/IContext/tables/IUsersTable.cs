////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;

namespace SharedLib
{
    /// <summary>
    /// Интерфейс доступа к данным пользователей
    /// </summary>
    public interface IUsersTable : ISavingChanges
    {
        /// <summary>
        /// Проверка существования пользователя с логином или паролем.
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="email">Пароль</param>
        /// <returns>Результат проверки. True - если есть пользователь с таким логином или email</returns>
        public Task<bool> AnyByLoginOrEmailAsync(string login, string email);

        /// <summary>
        /// Найти профил пользователя по логину
        /// </summary>
        /// <param name="login">Логин пользоввателя, которого нужно найти</param>
        /// <param name="inc_password">Включить в запрос хеш пароля</param>
        /// <param name="inc_metadata">Включить в запрос метаданные (Email, Уровень доступа/прав пользователя, Тип подтверждения учётной записи пользователя)</param>
        /// <param name="inc_profile">Включить в запрос профиль (Login, E-mail)</param>
        /// <returns>Профиль пользователя</returns>
        public Task<UserModelDB?> FirstOrDefaultByLoginAsync(string login, bool inc_password, bool inc_metadata, bool inc_profile);

        /// <summary>
        /// Найти профил пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="inc_password">Включить в запрос хеш пароля</param>
        /// <param name="inc_metadata">Включить в запрос метаданные (Email, Уровень доступа/прав пользователя, Тип подтверждения учётной записи пользователя)</param>
        /// <param name="inc_profile">Включить в запрос профиль (Login, E-mail)</param>
        /// <returns>Объект пользователя</returns>
        public Task<UserModelDB?> FirstOrDefaultAsync(int id, bool inc_password, bool inc_metadata, bool inc_profile);

        /// <summary>
        /// Найти профил пользователя по e-mail
        /// </summary>
        /// <param name="email">e-mail пользоввателя, которого нужно найти</param>
        /// <returns>Профиль пользователя</returns>
        public Task<UserModelDB?> FirstOrDefaultByEmailAsync(string email);

        /// <summary>
        /// Добавить новый профиль пользователя в БД
        /// </summary>
        /// <param name="user">Профиль пользователя</param>
        /// <param name="auto_save">Автоматически записать изменения в БД</param>
        public Task AddAsync(UserModelDB user, bool auto_save = true);

        /// <summary>
        /// Обновить профиль пользователя в БД
        /// </summary>
        /// <param name="user">Профиль пользователя</param>
        /// <param name="auto_save">Автоматически записать изменения в БД</param>
        public Task UpdateAsync(UserModelDB user, bool auto_save = true);

        //public Task<GetUserProfileResponseModel> UpdateMediumAsync(UserMediumModel user, bool auto_save = true);

        /// <summary>
        /// Поиск данных пользовтелей
        /// </summary>
        /// <param name="filter">Запрос/фильтр пользователей для поиска</param>
        /// <returns>Данные пользователей, найденные по запросу filter</returns>
        public Task<UserLiteModel[]?> FindUsersDataAsync(FindUsersProfilesRequestModel filter);

        /// <summary>
        /// Получить/прочитать данные пользователя по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Данные пользователя</returns>
        public Task<UserLiteModel?> GetUserDataAsync(int id);

        /// <summary>
        /// Проверить (асинхронно) пароль пользователя
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя проверки</param>
        /// <param name="password_hash">Хеш пароля пользователя для проверки</param>
        /// <returns></returns>
        public Task<bool> PasswordEqualByUserIdAsync(int user_id, string password_hash);

        /// <summary>
        /// Обновить хеш пароля пользователя
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя для обновления хеша пароля</param>
        /// <param name="password_hash">Хеш пароля (НОВЫЙ) для обновления его в БД</param>
        public Task PasswordUpdateByUserIdAsync(int user_id, string password_hash);

        /// <summary>
        /// Получить/прочитать данные пользователя по логину
        /// </summary>
        /// <param name="login">Логин пользователя, который нужно прочитать из БД</param>
        /// <returns>Даные пользователя</returns>
        public Task<UserLiteModel?> GetUserDataAsync(string login);
    }
}