using AngularMultiLanguage.Entities;

namespace AngularMultiLanguage.Data.Interfaces
{
    public interface ICountry
    {
        Task<IEnumerable<TblCountry>> GetAllCountriesAsync(string langCode = "en");
        Task<TblCountry> AddCountryAsync(TblCountry model);
        Task<TblCountry?> GetCountryAsync(Guid id);
        Task<IEnumerable<TblCountryTran>> GetCountrylangAsync(Guid? id);
        Task<bool> DeleteCountryAsync(Guid Id);
    }
}
