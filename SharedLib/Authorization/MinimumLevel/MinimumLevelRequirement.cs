////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Microsoft.AspNetCore.Authorization;

namespace SharedLib;

/// <summary>
/// Представляет требование авторизации.
/// </summary>
public class MinimumLevelRequirement : IAuthorizationRequirement
{
    /// <summary>
    /// Минимальный требуемый уровень прав
    /// </summary>
    public AccessLevelsUsersEnum Level { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="level">Минимальный требуемый уровень прав</param>
    public MinimumLevelRequirement(AccessLevelsUsersEnum level) { Level = level; }
}
