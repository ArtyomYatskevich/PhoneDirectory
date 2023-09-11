using PhoneDirectory.Backend.Models.Models.Base;

namespace PhoneDirectory.Backend.Models.Models;

public class User : Entity
{
    public required string Email { get; set; }

    // should be password hash and salt
    public required string Password { get; set; }
    
    #region Navigation properties

    public virtual ICollection<Phone>? Phones { get; set; }

    #endregion
}