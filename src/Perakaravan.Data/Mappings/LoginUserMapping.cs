using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Perakaravan.Domain.Entities;

namespace Perakaravan.Data.Mappings
{
    public class LoginUserMapping : EntityMapping<LoginUser>
    {
        public override void ConfigureDerivedEntity(EntityTypeBuilder<LoginUser> builder)
        {
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("nvarchar(30)").HasColumnOrder(2);

            builder.Property(x => x.Surname).HasColumnName("Surname").HasColumnType("nvarchar(30)").HasColumnOrder(3);
            builder.Property(x => x.Username).HasColumnName("Username").HasColumnType("nvarchar(10)").HasColumnOrder(4);
            builder.Property(x => x.Password).HasColumnName("Password").HasColumnType("nvarchar(80)").HasColumnOrder(5);
            builder.Property(x => x.Email).HasColumnName("Email").HasColumnType("nvarchar(150)").HasColumnOrder(6);
            builder.Property(x => x.Phone).HasColumnName("Phone").HasColumnType("nvarchar(50)").HasColumnOrder(7);
            builder.Property(x => x.RefreshToken).IsRequired(false).HasColumnName("RefreshToken").HasColumnType("nvarchar(150)").HasColumnOrder(8);
            builder.Property(x => x.RefreshTokenExpire).HasColumnName("RefreshTokenExpire").HasColumnOrder(9);

            #region Seed Data

            builder.HasData(new LoginUser
            {
                Id = 1,
                Name = "İsmet Aydın",
                Surname = "YURTSEVER",
                Username = "isayyu",
                Password = "isayyu123",
                Email = "ismet@gmail.com",
                Phone = "5053818226"
            },
            new LoginUser
            {
                Id = 2,
                Name = "Halil İbrahim",
                Surname = "ARAÇ",
                Username = "ibrahim",
                Password = "ibrahim123",
                Email = "ibrahim@gmail.com",
                Phone = "5053818226"
            });

            #endregion

            builder.ToTable("LoginUsers");
        }
    }
}
