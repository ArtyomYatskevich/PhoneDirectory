using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PD.Auth;

namespace PhoneDirectory.Backend.Controllers.Base;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BaseController : ControllerBase
{
    protected int GetUserId()
    {
        var userId = User.Identities
            .FirstOrDefault()
            ?.Claims
            .FirstOrDefault(c => c.Type == AuthConstants.UserIdClaim)
            ?.Value;
        
        if (userId is null)
        {
            throw new UnauthorizedAccessException();
        }
        
        return Convert.ToInt32(userId);
    }
}