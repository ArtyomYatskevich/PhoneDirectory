using PhoneDirectory.Backend.Application.Interfaces.Services;
using PhoneDirectory.Backend.Application.Mappings;
using PhoneDirectory.Backend.Application.Models.Phones;
using PhoneDirectory.Backend.Domain.Interfaces.Services;

namespace PhoneDirectory.Backend.Application.Services;

public class PhoneAppService : IPhoneAppService
{
    private readonly IPhoneService _phoneService;

    public PhoneAppService(IPhoneService phoneService)
    {
        _phoneService = phoneService;
    }

    public async Task<PhoneModel> AddAsync(AddPhoneModel model, int userId)
    {
        var entity = await _phoneService.AddAsync(model.ToEntity(userId));
        return entity.ToModel();
    }

    public async Task<PhoneModel> UpdateAsync(UpdatePhoneModel model, int id, int userId)
    {
        var entity = await _phoneService.UpdateAsync(model.ToEntity(userId, id));
        return entity.ToModel();
    }

    public async Task DeleteAsync(int id)
    {
        await _phoneService.DeleteAsync(id);
    }

    public async Task<IEnumerable<PhoneModel>> GetByUserIdAsync(int userId)
    {
        var entities = await _phoneService.GetAllAsync(userId);

        return entities.ToModel();
    }
}