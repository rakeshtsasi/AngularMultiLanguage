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

        public DbSet<TblAppLangMaster>? TblAppLangMasters { get; set; }
        public DbSet<TblCountry>? TblCountries { get; set;}
        public DbSet<TblCountryTran>? TblCountryTrans { get; set; }
    }
}
