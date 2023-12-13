using SecureApi.Web.Models;

namespace SecureApi.Web.Services.Cryptography;

public abstract class PasswordManagerBase
    : IPasswordManager
{
    public abstract int Version { get; }

    public async Task<Password> CreateFromPlaintextAsync(string plaintext)
    {
        var salt = await GenerateSaltAsync();

        return await CreateFromPlaintextAsync(plaintext, salt);
    }

    public async Task<Password> CreateFromPlaintextAsync(string plaintext, byte[] salt)
    {
        var hash = await HashPasswordAsync(plaintext, salt);

        return new Password(hash, salt, Version);
    }

    public async Task<bool> VerifyAsync(string plaintext, Password password)
    {
        var otherPassword = await CreateFromPlaintextAsync(plaintext, password.SaltBytes);

        return password == otherPassword;
    }

    protected abstract Task<byte[]> GenerateSaltAsync();
    protected abstract Task<byte[]> HashPasswordAsync(string plaintext, byte[] salt);
}
