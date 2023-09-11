using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Backend.Data.Contexts;
using PhoneDirectory.Backend.Domain.Interfaces.Services;
using PhoneDirectory.Backend.Models.Models;

namespace PhoneDirectory.Backend.Domain.Services;

public class UserService : IUserService
{
    private readonly PhoneDirectoryContext _dbContext;

    public UserService(PhoneDirectoryContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
    }
}