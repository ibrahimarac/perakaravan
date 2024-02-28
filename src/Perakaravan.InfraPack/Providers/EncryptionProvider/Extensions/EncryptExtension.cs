using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Attributes;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Converters;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Interfaces;

namespace Perakaravan.InfraPack.Providers.EncryptionProvider.Extensions
{
    public static class EncryptExtension
    {
        public static void UseEncryption(this ModelBuilder modelBuilder, IEncryptionProvider encryptionProvider)
        {
            if (modelBuilder is null)
                throw new ArgumentNullException(nameof(modelBuilder), "There is not ModelBuilder object.");
            if (encryptionProvider is null)
                throw new ArgumentNullException(nameof(encryptionProvider), "You should create encryption provider.");

            var encryptionConverter = new EncryptedConverter(encryptionProvider);
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(string) && !IsDiscriminator(property))
                    {
                        object[] attributes = property.PropertyInfo.GetCustomAttributes(typeof(EncryptAttribute), false);
                        if (attributes.Any())
                            property.SetValueConverter(encryptionConverter);
                    }
                }
            }
        }

        private static bool IsDiscriminator(IMutableProperty property) => property.Name == "Discriminator" || property.PropertyInfo == null;
    }
}
