using PhoneDirectory.Backend.Models.Models.Base;

namespace PhoneDirectory.Backend.Models.Models;

public class Phone : Entity
{
    public int UserId { get; set; }

    public required string Number { get; set; }
    
    #region Navigation properties

    public virtual User User { get; set; }

    #endregion
}