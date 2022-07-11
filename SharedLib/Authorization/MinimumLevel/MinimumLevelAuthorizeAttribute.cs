////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Microsoft.AspNetCore.Authorization;

namespace SharedLib;

/// <summary>
/// ”казывает, что дл€ класса или метода, к которому примен€етс€ этот атрибут, требуетс€ указанна€ авторизаци€.
/// </summary>
public class MinimumLevelAuthorizeAttribute : AuthorizeAttribute
{
    string POLICY_PREFIX = MinimumLevelPolicyProvider.POLICY_PREFIX;

    /// <summary>
    ///  онструктор
    /// </summary>
    /// <param name="level">ћинимальный требуемый уровень доступа</param>
    public MinimumLevelAuthorizeAttribute(AccessLevelsUsersEnum level) => Level = level;

    /// <summary>
    /// “екущий минимальный требуемый уровень доступа
    /// </summary>
    public AccessLevelsUsersEnum Level
    {
        get
        {
            if (AccessLevelsUsersEnum.TryParse(Policy.AsSpan(POLICY_PREFIX.Length), out AccessLevelsUsersEnum level))
            {
                return level;
            }
            return default;
        }
        set
        {
            Policy = $"{POLICY_PREFIX}{value}";
        }
    }
}
