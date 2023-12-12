using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace SecureApi.Web.Services.Cryptography;

public class PasswordManagerV1
    : PasswordManagerBase
{
    private readonly PasswordManagerV1Options _options;

    protected override int Version => 1;

    public PasswordManagerV1(IOptions<PasswordManagerV1Options> options)
    {
        _options = options.Value;
    }

    protected override Task<byte[]> GenerateSaltAsync()
    {
        var saltBytes = RandomNumberGenerator.GetBytes(_options.SaltSize);

        return Task.FromResult(saltBytes);
    }

    protected override async Task<byte[]> HashPasswordAsync(string plaintext, byte[] salt)
    {
        using var hmac = new HMACSHA512(Convert.FromBase64String(_options.Secret));

        var plaintextBytes = Encoding.UTF8.GetBytes(plaintext);

        using var stream = new MemoryStream(plaintextBytes.Concat(salt).ToArray(), writable: false);
        
        var hashBytes = await hmac.ComputeHashAsync(stream);

        return hashBytes;
    }
}

public sealed class PasswordManagerV1Options
{
    public required int SaltSize { get; init; }
    public required string Secret { get; init; }
}