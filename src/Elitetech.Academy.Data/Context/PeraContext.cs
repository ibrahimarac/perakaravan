using Microsoft.EntityFrameworkCore;
using Perakaravan.Application.Constants;
using Perakaravan.Data.Mappings;
using Perakaravan.Domain.Entities;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Implementations;
using Perakaravan.InfraPack.Providers.EncryptionProvider.Extensions;

namespace Perakaravan.Data.Context
{
    public class PeraContext : DbContext
    {
        public PeraContext(DbContextOptions<PeraContext> options) : base(options)
        {

        }

        public DbSet<LoginUser> Announcements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Encryption
            modelBuilder.UseEncryption(new EncryptionProvider(ApplicationConstants.EncryptionKey));

            modelBuilder.ApplyConfiguration(new LoginUserMapping());
        }
    }
}
