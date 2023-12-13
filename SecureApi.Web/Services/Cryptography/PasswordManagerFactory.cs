namespace SecureApi.Web.Services.Cryptography;

public sealed class PasswordManagerFactory
    : IPasswordManageFactory
{
    private readonly IEnumerable<IPasswordManager> _passwordManagers;

    public PasswordManagerFactory(IEnumerable<IPasswordManager> passwordManagers)
    {
        _passwordManagers = passwordManagers;
    }

    public IPasswordManager Create(int version)
    {
        return _passwordManagers.Single(x => x.Version == version);
    }

    public IPasswordManager Create()
    {
        return _passwordManagers.MaxBy(x => x.Version)!;
    }
}
