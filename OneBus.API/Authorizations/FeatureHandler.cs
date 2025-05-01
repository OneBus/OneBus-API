using Microsoft.AspNetCore.Authorization;
using OneBus.Application.Interfaces.Services;
using System.Security.Claims;

namespace OneBus.API.Authorizations
{
    public class FeatureHandler : AuthorizationHandler<FeatureRequirement>
    {
        private readonly IUserTypeFeatureService _userTypeFeatureService;

        public FeatureHandler(IUserTypeFeatureService userTypeFeatureService)
        {
            _userTypeFeatureService = userTypeFeatureService;
        }

        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context, 
            FeatureRequirement requirement)
        {
            var success = ulong.TryParse(context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out ulong userId);

            if (success && await _userTypeFeatureService.HasPermissionAsync(userId, requirement.FeatureCode))
            {
                context.Succeed(requirement);
            }
        }
    }
}
