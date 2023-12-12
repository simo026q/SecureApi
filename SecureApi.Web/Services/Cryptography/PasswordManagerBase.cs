using SecureApi.Web.Models;

namespace SecureApi.Web.Services.Cryptography;

public abstract class PasswordManagerBase
    : IPasswordManager
{
    protected abstract int Version { get; }

    public Password CreateFromPlaintext(string plaintext)
    {
        var salt = GenerateSalt();

        return CreateFromPlaintext(plaintext, salt);
    }

    public Password CreateFromPlaintext(string plaintext, byte[] salt)
    {
        var hash = HashPassword(plaintext, salt);

        return new Password(hash, salt, Version);
    }

    public bool Verify(string plaintext, Password password)
    {
        var otherPassword = CreateFromPlaintext(plaintext, password.SaltBytes);

        return password == otherPassword;
    }

    protected abstract byte[] GenerateSalt();
    protected abstract byte[] HashPassword(string plaintext, byte[] salt);
}
