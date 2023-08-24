using Microsoft.AspNetCore.Authorization;
using QuickLifeCoachingClinic.DataAccess.Entities;
using System.Security.Claims;

namespace QuickLifeCoachingClinic.Authorization
{
    public class MentorResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Mentor>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        ResourceOperationRequirement requirement,
        Mentor mentor)
        {
            if (requirement.ResourceOperation is ResourceOperation.Read or ResourceOperation.Create)
                context.Succeed(requirement);

            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (mentor.Id == int.Parse(userId)) context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
