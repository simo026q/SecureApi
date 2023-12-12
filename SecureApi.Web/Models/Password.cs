namespace SecureApi.Web.Models;

public readonly struct Password
    : IEquatable<Password>
{
    public string Hash { get; }
    public string Salt { get; }
    public int Version { get; }

    public byte[] HashBytes => Convert.FromBase64String(Hash);
    public byte[] SaltBytes => Convert.FromBase64String(Salt);

    public Password(string hash, string salt, int version)
    {
        Hash = hash;
        Salt = salt;
        Version = version;
    }

    public Password(byte[] hashBytes, byte[] saltBytes, int version)
        : this(Convert.ToBase64String(hashBytes), Convert.ToBase64String(saltBytes), version)
    { }

    public bool Equals(Password other)
    {
        return Hash == other.Hash && Salt == other.Salt && Version == other.Version;
    }

    public override bool Equals(object? obj)
    {
        return obj is Password other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Hash, Salt, Version);
    }

    public static bool operator ==(Password left, Password right) => left.Equals(right);
    public static bool operator !=(Password left, Password right) => !left.Equals(right);
}
