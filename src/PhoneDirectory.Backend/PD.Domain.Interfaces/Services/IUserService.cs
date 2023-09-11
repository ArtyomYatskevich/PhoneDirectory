using PhoneDirectory.Backend.Models.Models;

namespace PhoneDirectory.Backend.Domain.Interfaces.Services;

public interface IUserService
{
    Task AddAsync(User entity);

    Task<User?> GetUserByEmail(string email);
}