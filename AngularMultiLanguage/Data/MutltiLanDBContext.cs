using AngularMultiLanguage.Entities;
using Microsoft.EntityFrameworkCore;

namespace AngularMultiLanguage.Data
{
    public class MutltiLanDBContext : DbContext
    {
        public MutltiLanDBContext(DbContextOptions<MutltiLanDBContext> options):
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Insert these values to db at migration time
            modelBuilder.Entity<TblAppLangMaster>().HasData(
                new TblAppLangMaster
                {
                    LangCode ="en",
                    LangName ="English",
                    IsDefault = true,
                },
                new TblAppLangMaster
                {
                    LangCode = "ar",
                    LangName = "Arabic",
                    IsDefault = false,
                }
                );

            modelBuilder.Entity<TblCountry>(
                b =>
                {
                    b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
                    b.Property(u => u.CreatedAt).HasDefaultValueSql("getutcdate()");
                    b.HasIndex(u =>new {u.CreatedAt});
                }
                );

            modelBuilder.Entity<TblCountryTran>(b =>
            {
                b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
                b.HasKey(u => new { u.Id, u.CountryId, u.LangCode });
                b.HasIndex(u=>new {u.CountryId,u.LangCode}).IsUnique();
            });
        }

        public DbSet<TblAppLangMaster>? TblAppLangMasters { get; set; }
        public DbSet<TblCountry>? TblCountries { get; set;}
        public DbSet<TblCountryTran>? TblCountryTrans { get; set; }
    }
}
