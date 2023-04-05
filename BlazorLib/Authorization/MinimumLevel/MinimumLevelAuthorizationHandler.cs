////////////////////////////////////////////////
// � https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using SharedLib.Models;

namespace SharedLib;

/// <summary>
/// ���������� �����������, ������� ���������� ��� ���������� �����������.
/// </summary>
public class MinimumLevelAuthorizationHandler : AuthorizationHandler<MinimumLevelRequirement>
{
    private readonly ILogger<MinimumLevelAuthorizationHandler> _logger;

    /// <summary>
    /// �����������
    /// </summary>
    /// <param name="logger"></param>
    public MinimumLevelAuthorizationHandler(ILogger<MinimumLevelAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// ��������� ������� � ���������� ����������� �� ������ ����������� ����������.
    /// </summary>
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumLevelRequirement requirement)
    {
        if (context.User.HasClaim(c => c.Type == ClaimTypes.Role))
        {
            Claim? role = context.User.FindFirst(c => c.Type == ClaimTypes.Role);
            if (role is null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            AccessLevelsUsersEnum userRole = (AccessLevelsUsersEnum)Enum.Parse(typeof(AccessLevelsUsersEnum), role.Value);
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
