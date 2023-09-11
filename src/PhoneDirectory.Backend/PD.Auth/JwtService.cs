using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PhoneDirectory.Backend.Application.Models.Users;
using PhoneDirectory.Backend.Infrastructure.Configs;
using PhoneDirectory.Backend.Infrastructure.Utilities;

namespace PD.Auth;

public interface IJwtService
{
    public string GenerateJwtToken(UserModel model);
    
    string GenerateRefreshToken(int userId);
}

public class JwtService : IJwtService
{
    private const int RefreshTokenLength = 40;

    private readonly AuthConfig _authConfig;
    
    public JwtService(IOptions<AuthConfig> authConfigOptions)
    {
        _authConfig = authConfigOptions.Value;
    }

    public string GenerateJwtToken(UserModel model)
    {
        var dateTimeNow = DateTime.Now;
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authConfig.SecretKey)),
            SecurityAlgorithms.HmacSha256Signature);

        var claims = new List<Claim>
        {
            new (AuthConstants.UserIdClaim, model.Id.ToString()),
            new (JwtRegisteredClaimNames.Email, model.Email),
        };
        
        var jwt = new JwtSecurityToken(
            _authConfig.Issuer,
            _authConfig.Audience,
            claims,
            dateTimeNow,
            DateTime.UtcNow.AddDays(_authConfig.AuthTokenLifeDays),
            signingCredentials);
        
        var token = new JwtSecurityTokenHandler().WriteToken(jwt);
        return token;
    }
    
    public string GenerateRefreshToken(int userId)
    {
        // need to store somewhere
        
        return Randomizer.RandomTokenString(RefreshTokenLength);
    }
}