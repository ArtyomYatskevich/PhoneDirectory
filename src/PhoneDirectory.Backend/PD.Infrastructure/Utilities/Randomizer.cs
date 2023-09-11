using System.Security.Cryptography;

namespace PhoneDirectory.Backend.Infrastructure.Utilities;

public class Randomizer
{
    public static string RandomTokenString(int length)
    {
        var bytes = RandomNumberGenerator.GetBytes(length / 2);
            
        // convert random bytes to hex string
        return BitConverter.ToString(bytes).Replace("-", "");
    }
}