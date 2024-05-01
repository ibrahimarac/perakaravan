using Microsoft.EntityFrameworkCore;
using Perakaravan.Data.Mappings;
using Perakaravan.Domain.Entities;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Extensions;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Interfaces;

namespace Perakaravan.Data.Context
{
    public class PeraContext : DbContext
    {
        private readonly IEncryptionProvider _encryptionProvider;

        public PeraContext(DbContextOptions<PeraContext> options, IEncryptionProvider encryptionProvider) : base(options)
        {
            _encryptionProvider = encryptionProvider;
        }

        public DbSet<LoginUser> LoginUsers { get; set; }
        public object ApplicationConstants { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Encryption
            modelBuilder.UseEncryption(_encryptionProvider);

            modelBuilder.ApplyConfiguration(new LoginUserMapping());
        }

    }
}
