using Microsoft.AspNetCore.Authorization;
using QuickHealthClinic.DataAccess.Entities;

namespace QuickHealthClinic.Authorization
{
    public class DoctorResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Doctor>
    {
        
    }
}
