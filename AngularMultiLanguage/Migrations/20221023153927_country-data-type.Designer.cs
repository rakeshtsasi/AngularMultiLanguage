﻿// <auto-generated />
using System;
using AngularMultiLanguage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AngularMultiLanguage.Migrations
{
    [DbContext(typeof(MutltiLanDBContext))]
    [Migration("20221023153927_country-data-type")]
    partial class countrydatatype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AngularMultiLanguage.Entities.TblAppLangMaster", b =>
                {
                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(2)");

                    b.Property<bool?>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("LangName")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("LangCode");

                    b.ToTable("TblAppLangMasters");

                    b.HasData(
                        new
                        {
                            LangCode = "en",
                            IsDefault = true,
                            LangName = "English"
                        },
                        new
                        {
                            LangCode = "ar",
                            IsDefault = false,
                            LangName = "Arabic"
                        });
                });

            modelBuilder.Entity("AngularMultiLanguage.Entities.TblCountry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CreatedAt");

                    b.ToTable("TblCountries");
                });

            modelBuilder.Entity("AngularMultiLanguage.Entities.TblCountryTran", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LangCode")
                        .HasColumnType("varchar(2)");

                    b.Property<string>("CountryName")
                        .HasColumnType("NVARCHAR(150)");

                    b.HasKey("Id", "CountryId", "LangCode");

                    b.HasIndex("LangCode");

                    b.HasIndex("CountryId", "LangCode")
                        .IsUnique();

                    b.ToTable("TblCountryTrans");
                });

            modelBuilder.Entity("AngularMultiLanguage.Entities.TblCountryTran", b =>
                {
                    b.HasOne("AngularMultiLanguage.Entities.TblCountry", "TblCountry")
                        .WithMany("TblCountryTrans")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AngularMultiLanguage.Entities.TblAppLangMaster", "TblAppLangMaster")
                        .WithMany()
                        .HasForeignKey("LangCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TblAppLangMaster");

                    b.Navigation("TblCountry");
                });

            modelBuilder.Entity("AngularMultiLanguage.Entities.TblCountry", b =>
                {
                    b.Navigation("TblCountryTrans");
                });
#pragma warning restore 612, 618
        }
    }
}
