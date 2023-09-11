using PhoneDirectory.Backend.Application.Models.Phones;
using PhoneDirectory.Backend.Models.Models;

namespace PhoneDirectory.Backend.Application.Mappings;

public static class PhoneMapping
{
    public static Phone ToEntity(this AddPhoneModel model, int userId)
    {
        return new Phone
        {
            Name = model.Name,
            Number = model.Number,
            UserId = userId
        };
    }
    
    public static Phone ToEntity(this UpdatePhoneModel model, int userId, int id)
    {
        return new Phone
        {
            Id = id,
            Name = model.Name,
            Number = model.Number,
            UserId = userId
        };
    }
    
    public static PhoneModel ToModel(this Phone entity)
    {
        return new PhoneModel
        {
            Id = entity.Id,
            Name = entity.Name,
            Number = entity.Number,
        };
    }
    
    public static IEnumerable<PhoneModel> ToModel(this IEnumerable<Phone>? entities)
    {
        return entities is null ?
            Enumerable.Empty<PhoneModel>() :
            entities.Select(ToModel);
    }
}