using SecureApi.Web.Models;

namespace SecureApi.Web.Services.Cryptography;

public interface IPasswordManager
{
    Task<Password> CreateFromPlaintextAsync(string plaintext);
    Task<Password> CreateFromPlaintextAsync(string plaintext, byte[] salt);
    Task<bool> VerifyAsync(string plaintext, Password password);
}
