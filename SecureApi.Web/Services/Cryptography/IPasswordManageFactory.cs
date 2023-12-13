namespace SecureApi.Web.Services.Cryptography;

public interface IPasswordManageFactory
{
    IPasswordManager Create(int version);
    IPasswordManager Create();
}
