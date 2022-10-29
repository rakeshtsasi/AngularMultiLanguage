using AngularMultiLanguage.Data.Interfaces;
using AngularMultiLanguage.Entities;
using Microsoft.EntityFrameworkCore;

namespace AngularMultiLanguage.Data.Repo
{
    public class SQLCountry : ICountry
    {
        private readonly MutltiLanDBContext _db;
        public SQLCountry(MutltiLanDBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TblCountry>> GetAllCountriesAsync(
            string langCode = "en")
        {
            var countries = await _db.Set<TblCountry>()
               .Include(i => i.TblCountryTrans!.Where(l => l.LangCode == langCode))
               .ToListAsync();

            return countries;
        }
        public async Task<TblCountry> AddCountryAsync(TblCountry model)
        {
            await _db.Set<TblCountry>().AddAsync(model);
            await _db.SaveChangesAsync();
            return model;
        }



        public async Task<bool> DeleteCountryAsync(Guid Id)
        {
            var deleted = 0;
            var country = await _db.Set<TblCountry>().FindAsync(Id);

            if (country is not null)
            {
                _db.Set<TblCountry>().Remove(country);
                deleted = await _db.SaveChangesAsync();

            }
            return deleted > 0;
        }

        public async Task<TblCountry?> GetCountryAsync(Guid id)
        {
            var country = await _db.Set<TblCountry>()
                .FindAsync(id);

            return country;
        }

        public async Task<IEnumerable<TblCountryTran>> GetCountrylangAsync(Guid? id)
        {
            var result = id is not null ?
                await _db.Set<TblAppLangMaster>()
                .OrderByDescending(x => x.IsDefault)
                .Select(x => new TblCountryTran
                {
                    LangCode = x.LangCode,
                    CountryName = x.TblCountryTrans!.Any(l => l.LangCode == x.LangCode &&
                     l.CountryId == id) ?
                    x.TblCountryTrans!.FirstOrDefault(l => l.LangCode == x.LangCode &&
                    l.CountryId == id)!.CountryName :
                    string.Empty
                }).ToListAsync() :

                 await _db.Set<TblAppLangMaster>()
                .OrderByDescending(x => x.IsDefault)
                .Select(x => new TblCountryTran
                {
                    LangCode = x.LangCode,
                    CountryName = string.Empty

                }).ToListAsync();
            return result;
        }
    }
}
