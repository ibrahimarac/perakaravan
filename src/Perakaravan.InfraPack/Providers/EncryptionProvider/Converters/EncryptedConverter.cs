using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Interfaces;

namespace Perakaravan.InfraPack.Providers.EncryptionProvider.Converters
{
    public class EncryptedConverter : ValueConverter<string, string>
    {
        public EncryptedConverter(IEncryptionProvider encryptionProvider, ConverterMappingHints mappingHints = null) : base(x => encryptionProvider.Encrypt(x), x => encryptionProvider.Decrypt(x), mappingHints)
        {

        }


    }
}
