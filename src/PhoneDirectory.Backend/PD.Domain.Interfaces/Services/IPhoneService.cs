using PhoneDirectory.Backend.Models.Models;

namespace PhoneDirectory.Backend.Domain.Interfaces.Services;

public interface IPhoneService
{
    Task<Phone> AddAsync(Phone entity);
    
    Task<Phone> UpdateAsync(Phone entity);

    Task DeleteAsync(int id);

    Task<List<Phone>> GetAllAsync(int userId);
}