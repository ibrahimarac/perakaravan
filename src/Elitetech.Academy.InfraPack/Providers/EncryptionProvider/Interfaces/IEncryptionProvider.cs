namespace Perakaravan.InfraPack.Providers.EncryptionProvider.Interfaces
{
    public interface IEncryptionProvider
    {
        string Encrypt(string plainText);
        string Decrypt(string cipherText);
    }
}
