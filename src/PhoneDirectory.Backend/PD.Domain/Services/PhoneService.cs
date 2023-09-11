using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Backend.Data.Contexts;
using PhoneDirectory.Backend.Domain.Interfaces.Services;
using PhoneDirectory.Backend.Infrastructure.Exceptions;
using PhoneDirectory.Backend.Models.Models;

namespace PhoneDirectory.Backend.Domain.Services;

public class PhoneService : IPhoneService
{
    private readonly PhoneDirectoryContext _dbContext;

    public PhoneService(PhoneDirectoryContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Phone> AddAsync(Phone entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<Phone> UpdateAsync(Phone entity)
    {
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
        
        return entity;
    }
    
    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.Phones.FirstOrDefaultAsync(x => x.Id == id);
        if (entity is null)
        {
            throw new NotFoundException("Phone not found");
        }
        
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Phone>> GetAllAsync(int userId)
    {
        return await _dbContext.Phones
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }
}