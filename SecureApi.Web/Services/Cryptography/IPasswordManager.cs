using SecureApi.Web.Models;

namespace SecureApi.Web.Services.Cryptography;

public interface IPasswordManager
{
    Password CreateFromPlaintext(string plaintext);
    Password CreateFromPlaintext(string plaintext, byte[] salt);
    bool Verify(string plaintext, Password password);
}
