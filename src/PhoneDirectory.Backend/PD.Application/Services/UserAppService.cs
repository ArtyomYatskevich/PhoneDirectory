using PD.Auth;
using PhoneDirectory.Backend.Application.Interfaces.Services;
using PhoneDirectory.Backend.Application.Models.Users;
using PhoneDirectory.Backend.Domain.Interfaces.Services;
using PhoneDirectory.Backend.Infrastructure.Exceptions;

namespace PhoneDirectory.Backend.Application.Services;

public class UserAppService : IUserAppService
{
    private readonly IJwtService _jwtService;
    private readonly IUserService _userService;

    public UserAppService(IJwtService jwtService, IUserService userService)
    {
        _jwtService = jwtService;
        _userService = userService;
    }

    public async Task<AuthenticateResponseModel> AuthenticateAsync(AuthenticateRequestModel model)
    {
        var user = await _userService.GetUserByEmail(model.Email);
        if (user is null || !user.Password.Equals(model.Password))
        {
            throw new NotFoundException("Email or password is incorrect!");
        }
        
        var userModel = new UserModel
        {
            Id = user.Id,
            Email = user.Email,
            Name = user.Name
        };

        var token = _jwtService.GenerateJwtToken(userModel);

        return new AuthenticateResponseModel
        {
            UserId = user.Id,
            Email = user.Email,
            Token = token,
            RefreshToken = _jwtService.GenerateRefreshToken(user.Id)
        };
    }
}