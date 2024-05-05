using Microsoft.EntityFrameworkCore;
using Perakaravan.Data.Extensions;
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
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SiteStatic> SiteStatics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //QueryFilter
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                var isActive = type.FindProperty("IsDeleted");
                if (isActive != null && isActive.ClrType == typeof(bool))
                    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }

            //Encryption
            modelBuilder.UseEncryption(_encryptionProvider);

            //Mappings
            modelBuilder.ApplyConfiguration(new LoginUserMapping());
            modelBuilder.ApplyConfiguration(new SliderMapping());
            modelBuilder.ApplyConfiguration(new SiteStaticMapping());
        }

    }
}
