using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Perakaravan.Domain.Entities;

namespace Perakaravan.Data.Mappings
{
    public class SliderMapping : EntityMapping<Slider>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("varchar(150)").HasColumnOrder(2);

            builder.Property(x => x.SubTitle).HasColumnName("SubTitle").HasColumnType("varchar(300)").HasColumnOrder(3);
            builder.Property(x => x.ImageUrl).HasColumnName("ImageUrl").HasColumnType("varchar(150)").HasColumnOrder(4);
            builder.Property(x => x.RedirectUrl).HasColumnName("RedirectUrl").HasColumnType("varchar(150)").HasColumnOrder(5);

            builder.ToTable("Slider");
        }
    }
}
