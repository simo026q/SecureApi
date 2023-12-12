using SecureApi.Web.Models;

namespace SecureApi.Web.Services.Cryptography;

public class PasswordManagerV1
    : PasswordManagerBase
{
    protected override int Version => 1;

    protected override byte[] GenerateSalt()
    {
        throw new NotImplementedException();
    }

    protected override byte[] HashPassword(string plaintext, byte[] salt)
    {
        throw new NotImplementedException();
    }
}
