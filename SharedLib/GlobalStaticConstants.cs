////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib;
/// <summary>
/// Константы
/// </summary>
public static class GlobalStaticConstants
{
    #region имена полей для хранения информации о сессии

    /// <summary>
    /// имя поля в storage браузера для хранения информации о 'id пользователя' сессии
    /// </summary>
    public const string SESSION_STORAGE_KEY_USER_ID = "session_user_id";

    /// <summary>
    /// имя поля в storage браузера для хранения информации о 'логине' сессии
    /// </summary>
    public const string SESSION_STORAGE_KEY_LOGIN = "session_login";

    /// <summary>
    /// имя поля в storage браузера для хранения информации о 'уровне доступа' сессии
    /// </summary>
    public const string SESSION_STORAGE_KEY_LEVEL = "session_level";

    /// <summary>
    /// имя поля в storage браузера для хранения информации о 'токене' сессии
    /// </summary>
    public const string SESSION_STORAGE_KEY_TOKEN = "session_token";

    #endregion

    /// <summary>
    /// Имя заголовка для пердачи токена от клиента к серверу
    /// </summary>
    public const string SESSION_TOKEN_NAME = "token";

    #region имена контроллеров и действий

    /// <summary>
    /// Аутентификация
    /// </summary>
    public const string AUTHENTICATION_CONTROLLER_NAME = "authentication";

    /// <summary>
    /// Пользователи
    /// </summary>
    public const string USERS_CONTROLLER_NAME = "users";

    /// <summary>
    /// Перечисления (enum`s)
    /// </summary>
    public const string ENUMS_CONTROLLER_NAME = "enums";

    /// <summary>
    /// Документы
    /// </summary>
    public const string DOCUMENTS_CONTROLLER_NAME = "documents";

    /// <summary>
    /// Проекты
    /// </summary>
    public const string PROJECTS_CONTROLLER_NAME = "projects";




    /// <summary>
    /// Редактировать
    /// </summary>
    public const string EDIT_ACTION_NAME = "edit";

    /// <summary>
    /// Список
    /// </summary>
    public const string LIST_ACTION_NAME = "list";

    /// <summary>
    /// Профиль
    /// </summary>
    public const string PROFILE_ACTION_NAME = "profile";

    /// <summary>
    /// Выйти
    /// </summary>
    public const string LOGOUT_ACTION_NAME = "logout";

    /// <summary>
    /// Войти
    /// </summary>
    public const string LOGIN_ACTION_NAME = "login";

    /// <summary>
    /// Восстановить
    /// </summary>
    public const string RESTORE_ACTION_NAME = "restore";

    /// <summary>
    /// Регистрация
    /// </summary>
    public const string REGISTRATION_ACTION_NAME = "registration";

    #endregion

    /// <summary>
    /// Имя пространства имён мемкеша для хранения сессий
    /// </summary>
    public const string SESSION_MEMCASHE_NAMESPASE = "sessions";

    /// <summary>
    /// Шаблон системного кодового имени
    /// </summary>
    public const string SYSTEM_CODE_NAME_TEMPLATE = @"^[a-zA-Z][a-zA-Z0-9_]{1,72}[a-zA-Z0-9]{1,72}$";

    /// <summary>
    /// Шаблон пространства имён
    /// </summary>
    public const string NAME_SPACE_TEMPLATE = @"^[a-zA-Z][a-zA-Z0-9_\.]{1,72}[a-zA-Z0-9]{1,128}$";

    #region for constructor tree

    /// <summary>
    /// Префикс имени поля данных для документа-объекта
    /// </summary>
    public const string TABLE_PROPERTY_NAME_PREFIX = "_TableProperty";

    /// <summary>
    /// Префикс типа данных табличных данных документа
    /// </summary>
    public const string TABLE_TYPE_NAME_PREFIX = "_TableModel";

    /// <summary>
    /// Префикс имени поля (имя таблицы БД) для контекста базы данных
    /// </summary>
    public const string CONTEXT_DATA_SET_PREFIX = "_DbSet";

    /// <summary>
    /// Префикс сервиса непосредственного доступа к данным БД
    /// </summary>
    public const string DATABASE_TABLE_ACESSOR_PREFIX = "_TableAccessor";

    /// <summary>
    /// Префикс сервиса/прокладки между контроллером и сервисом доступа к данным
    /// </summary>
    public const string SERVICE_ACESSOR_PREFIX = "_Service";

    /// <summary>
    /// Префикс модели rest/ответа одного элемента
    /// </summary>
    public const string SINGLE_REPONSE_MODEL_PREFIX = "_ResponseModel";

    /// <summary>
    /// Префикс модели rest/ответа коллекции элементов
    /// </summary>
    public const string MULTI_REPONSE_MODEL_PREFIX = "_ResponseListModel";

    /// <summary>
    /// Префикс модели rest/ответа с поддержкой пагинации
    /// </summary>
    public const string PAGINATION_REPONSE_MODEL_PREFIX = "_ResponsePaginationModel";

    /// <summary>
    /// Имя поля результат полезной нагрузки
    /// </summary>
    public const string RESULT_PROPERTY_NAME = "Result";

    #endregion
}