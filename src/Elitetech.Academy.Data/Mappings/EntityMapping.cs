using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Perakaravan.Domain.Common;

namespace Perakaravan.Data.Mappings
{
    public abstract class EntityMapping<T> : IEntityTypeConfiguration<T>
        where T : Entity
    {
        public abstract void ConfigureDerivedEntity(EntityTypeBuilder<T> builder);

        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id).HasColumnName("Id").HasColumnOrder(1);
            builder.HasKey(x => x.Id);

            //Diğer entity'den gelen propertyler gelir
            ConfigureDerivedEntity(builder);

            builder.Property(x => x.CreatedUser).HasColumnName("CreatedUser").HasColumnOrder(30);
            builder.Property(x => x.UpdatedUser).IsRequired(false).HasColumnName("UpdatedUser").HasColumnOrder(31);
            builder.Property(x => x.CreatedTime).HasColumnName("CreatedTime").HasColumnOrder(32);
            builder.Property(x => x.UpdatedTime).IsRequired(false).HasColumnName("UpdatedTime").HasColumnOrder(33);
        }
    }
}
