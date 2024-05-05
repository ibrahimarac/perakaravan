using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Perakaravan.Domain.Entities;

namespace Perakaravan.Data.Mappings
{
    public class SiteStaticMapping : EntityMapping<SiteStatic>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<SiteStatic> builder)
        {
            builder.Property(x => x.Phone).HasColumnName("Phone").HasColumnType("varchar(12)").HasColumnOrder(2);
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("varchar(200)").HasColumnOrder(3);
            builder.Property(x => x.Address).HasColumnName("Address").HasColumnType("varchar(255)").HasColumnOrder(4);
            builder.Property(x => x.GoogleMap).HasColumnName("GoogleMap").HasColumnType("varchar(50)").HasColumnOrder(5);
            builder.Property(x => x.Instagram).HasColumnName("Instagram").HasColumnType("varchar(150)").HasColumnOrder(6);
            builder.Property(x => x.Facebook).HasColumnName("Facebook").HasColumnType("varchar(150)").HasColumnOrder(7);
            builder.Property(x => x.Twitter).HasColumnName("Twitter").HasColumnType("varchar(150)").HasColumnOrder(8);
            builder.Property(x => x.HomepageTitle).HasColumnName("HomepageTitle").HasColumnType("varchar(255)").HasColumnOrder(9);
            builder.Property(x => x.Footer).HasColumnName("Footer").HasColumnType("varchar(255)").HasColumnOrder(10);
            builder.Property(x => x.Logo).HasColumnName("Logo").HasColumnType("varchar(100)").HasColumnOrder(11);
            builder.Property(x => x.LogoTitle).HasColumnName("LogoTitle").HasColumnType("varchar(100)").HasColumnOrder(12);
            builder.Property(x => x.SmtpUrl).HasColumnName("SmtpUrl").HasColumnType("varchar(100)").HasColumnOrder(13);
            builder.Property(x => x.SmtpDisplayName).HasColumnName("SmtpDisplayName").HasColumnType("varchar(100)").HasColumnOrder(14);
            builder.Property(x => x.SmtpPort).HasColumnName("SmtpPort").HasColumnOrder(15);

            builder.ToTable("SiteStatic");
        }
    }
}
