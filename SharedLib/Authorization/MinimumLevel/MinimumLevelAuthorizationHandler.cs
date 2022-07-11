////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using System.Security.Claims;
using SharedLib.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace SharedLib;

/// <summary>
/// Обработчик авторизации, которое вызывается для требований авторизации.
/// </summary>
public class MinimumLevelAuthorizationHandler : AuthorizationHandler<MinimumLevelRequirement>
{
    private readonly ILogger<MinimumLevelAuthorizationHandler> _logger;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="logger"></param>
    public MinimumLevelAuthorizationHandler(ILogger<MinimumLevelAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Принимает решение о разрешении авторизации на основе конкретного требования.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="requirement"></param>
    /// <returns></returns>
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumLevelRequirement requirement)
    {
        if (context.User.HasClaim(c => c.Type == ClaimTypes.Role))
        {
            AccessLevelsUsersEnum userRole = (AccessLevelsUsersEnum)Enum.Parse(typeof(AccessLevelsUsersEnum), context.User.FindFirst(c => c.Type == ClaimTypes.Role).Value);
            if (userRole >= requirement.Level)
            {
                context.Succeed(requirement);
            }
        }

        else
        {
            _logger.LogInformation("No Role claim present");
        }

        return Task.CompletedTask;
    }
}
