////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib.Models
{
    /// <summary>
    /// Запрос поиска пользователей
    /// </summary>
    public class FindUsersProfilesRequestModel : PaginationRequestModel
    {
        /// <summary>
        /// Поиск по логину
        /// </summary>
        public FindTextModel? FindLogin { get; set; }

        /// <summary>
        /// Поиск по уровню доступа
        /// </summary>
        public IEnumerable<AccessLevelsUsersEnum>? AccessLevelsUsers { get; set; }

        /// <summary>
        /// Типы подтверждения учётной записи пользователя
        /// </summary>
        public IEnumerable<ConfirmationUsersTypesEnum>? ConfirmationUsersTypes { get; set; }
    }
}
