using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PhoneDirectory.Backend.Application.Interfaces.Services;
using PhoneDirectory.Backend.Application.Models.Users;
using PhoneDirectory.Backend.Controllers.Base;
using PhoneDirectory.Backend.Infrastructure.Configs;

namespace PhoneDirectory.Backend.Controllers;

public class AuthController : BaseController
{
    private const string RefreshTokenCookieKey = "RefreshToken";
    private readonly IUserAppService _userAppService;
    private readonly AuthConfig _authConfig;

    public AuthController(IUserAppService userAppService, IOptions<AuthConfig> authConfigOptions)
    {
        _userAppService = userAppService;
        _authConfig = authConfigOptions.Value;
    }
    
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Authenticate(AuthenticateRequestModel model)
    {
        var result = await _userAppService.AuthenticateAsync(model);
        
        SetRefreshTokenCookies(result.RefreshToken);
        
        return Ok(result);
    }
    
    [HttpPost("logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete(RefreshTokenCookieKey);
        
        return Ok();
    }
    
    private void SetRefreshTokenCookies(string token)
    {
        Response.Cookies.Append(RefreshTokenCookieKey, token, new CookieOptions
        {
            Secure = true,
            Expires = DateTimeOffset.UtcNow.AddDays(_authConfig.CookieLifeDays),
            HttpOnly = true
        });
    }
}