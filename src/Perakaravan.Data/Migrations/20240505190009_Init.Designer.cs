﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Perakaravan.Data.Context;

#nullable disable

namespace Perakaravan.Data.Migrations
{
    [DbContext(typeof(PeraContext))]
    [Migration("20240505190009_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Perakaravan.Domain.Entities.LoginUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(32);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(30);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Email")
                        .HasColumnOrder(6);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Name")
                        .HasColumnOrder(2);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("Password")
                        .HasColumnOrder(5);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Phone")
                        .HasColumnOrder(7);

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("RefreshToken")
                        .HasColumnOrder(8);

                    b.Property<DateTime?>("RefreshTokenExpire")
                        .HasColumnType("datetime2")
                        .HasColumnName("RefreshTokenExpire")
                        .HasColumnOrder(9);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Surname")
                        .HasColumnOrder(3);

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(33);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(31);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Username")
                        .HasColumnOrder(4);

                    b.HasKey("Id");

                    b.ToTable("LoginUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedTime = new DateTime(2024, 5, 5, 22, 0, 7, 800, DateTimeKind.Unspecified).AddTicks(4792),
                            CreatedUser = "admin",
                            Email = "6i1RRb8yv2k93LY76uQYXg==",
                            IsDeleted = false,
                            Name = "İsmet Aydın",
                            Password = "oscldUV7cgbn0b8V8HmpyQ==",
                            Phone = "YCPrDtNs284S9G5ikUK4fA==",
                            Surname = "YURTSEVER",
                            Username = "isayyu"
                        },
                        new
                        {
                            Id = 2,
                            CreatedTime = new DateTime(2024, 5, 5, 22, 0, 7, 800, DateTimeKind.Unspecified).AddTicks(4840),
                            CreatedUser = "admin",
                            Email = "YPRqARSJPWq8wMRbcsaVck2Wnq3lgHLvl0z7T+wsoKc=",
                            IsDeleted = false,
                            Name = "Halil İbrahim",
                            Password = "PaFmrqp5h+CAYfGVZvjZsw==",
                            Phone = "YCPrDtNs284S9G5ikUK4fA==",
                            Surname = "ARAÇ",
                            Username = "ibrahim"
                        });
                });

            modelBuilder.Entity("Perakaravan.Domain.Entities.SiteStatic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Address")
                        .HasColumnOrder(4);

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(32);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(30);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Email")
                        .HasColumnOrder(3);

                    b.Property<string>("Facebook")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Facebook")
                        .HasColumnOrder(7);

                    b.Property<string>("Footer")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Footer")
                        .HasColumnOrder(10);

                    b.Property<string>("GoogleMap")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("GoogleMap")
                        .HasColumnOrder(5);

                    b.Property<string>("HomepageTitle")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("HomepageTitle")
                        .HasColumnOrder(9);

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Instagram")
                        .HasColumnOrder(6);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Logo")
                        .HasColumnOrder(11);

                    b.Property<string>("LogoTitle")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LogoTitle")
                        .HasColumnOrder(12);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("varchar(12)")
                        .HasColumnName("Phone")
                        .HasColumnOrder(2);

                    b.Property<string>("SmtpDisplayName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("SmtpDisplayName")
                        .HasColumnOrder(14);

                    b.Property<int?>("SmtpPort")
                        .HasColumnType("int")
                        .HasColumnName("SmtpPort")
                        .HasColumnOrder(15);

                    b.Property<string>("SmtpUrl")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("SmtpUrl")
                        .HasColumnOrder(13);

                    b.Property<string>("Twitter")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Twitter")
                        .HasColumnOrder(8);

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(33);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(31);

                    b.HasKey("Id");

                    b.ToTable("SiteStatic", (string)null);
                });

            modelBuilder.Entity("Perakaravan.Domain.Entities.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedTime")
                        .HasColumnOrder(32);

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CreatedUser")
                        .HasColumnOrder(30);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("ImageUrl")
                        .HasColumnOrder(4);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("RedirectUrl")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("RedirectUrl")
                        .HasColumnOrder(5);

                    b.Property<string>("SubTitle")
                        .IsRequired()
                        .HasColumnType("varchar(300)")
                        .HasColumnName("SubTitle")
                        .HasColumnOrder(3);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("Title")
                        .HasColumnOrder(2);

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("UpdatedTime")
                        .HasColumnOrder(33);

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedUser")
                        .HasColumnOrder(31);

                    b.HasKey("Id");

                    b.ToTable("Slider", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
