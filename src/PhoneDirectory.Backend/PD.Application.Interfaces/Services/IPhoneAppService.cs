using PhoneDirectory.Backend.Application.Models.Phones;

namespace PhoneDirectory.Backend.Application.Interfaces.Services;

public interface IPhoneAppService
{
    Task<PhoneModel> AddAsync(AddPhoneModel model, int userId);
    
    Task<PhoneModel> UpdateAsync(UpdatePhoneModel model, int id, int userId);

    Task DeleteAsync(int id);

    Task<IEnumerable<PhoneModel>> GetByUserIdAsync(int userId);
}