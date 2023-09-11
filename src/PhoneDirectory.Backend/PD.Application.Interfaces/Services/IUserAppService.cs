using PhoneDirectory.Backend.Application.Models.Users;

namespace PhoneDirectory.Backend.Application.Interfaces.Services;

public interface IUserAppService
{
    Task<AuthenticateResponseModel> AuthenticateAsync(AuthenticateRequestModel model);
}