////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using SharedLib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace SharedLib;

/// <summary>
/// Тип, который может предоставить Microsoft.AspNetCore.Authorization.AuthorizationPolicy для определенного имени.
/// </summary>
public class MinimumLevelPolicyProvider : IAuthorizationPolicyProvider
{
    /// <summary>
    /// Префикс имени политики
    /// </summary>
    public static string POLICY_PREFIX => "MinimumLevel";

    /// <summary>
    /// Поставщик резервной политики
    /// </summary>
    public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="options">Предоставляет программную конфигурацию, используемую службами Microsoft.AspNetCore.Authorization.IAuthorizationService и Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.</param>
    public MinimumLevelPolicyProvider(IOptions<AuthorizationOptions> options)
    {
        FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
    }

    /// <summary>
    /// Получить политику по умолчанию
    /// </summary>
    /// <returns>Представляет набор требований авторизации и схемы или схем, по которым они оцениваются, и все они должны быть успешными для успешной авторизации.</returns>
    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => FallbackPolicyProvider.GetDefaultPolicyAsync();

    /// <summary>
    /// Получить резервную политику
    /// </summary>
    /// <returns>Представляет набор требований авторизации и схемы или схем, по которым они оцениваются, и все они должны быть успешными для успешной авторизации.</returns>
    public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => FallbackPolicyProvider.GetFallbackPolicyAsync();

    /// <summary>
    /// Получить политику
    /// </summary>
    /// <param name="policyName">Имя политики</param>
    /// <returns>Представляет набор требований авторизации и схемы или схем, по которым они оцениваются, и все они должны быть успешными для успешной авторизации.</returns>
    public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
            AccessLevelsUsersEnum.TryParse(policyName.Substring(POLICY_PREFIX.Length), out AccessLevelsUsersEnum level))
        {
            AuthorizationPolicyBuilder? policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new MinimumLevelRequirement(level));
            return Task.FromResult(policy.Build());
        }

        return FallbackPolicyProvider.GetPolicyAsync(policyName);
    }
}
