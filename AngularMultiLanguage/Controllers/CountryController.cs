using AngularMultiLanguage.Data;
using AngularMultiLanguage.Data.Interfaces;
using AngularMultiLanguage.Entities;
using AngularMultiLanguage.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularMultiLanguage.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IRepoWrapper _repoWrapper;

        public CountryController(IRepoWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [HttpGet,Route("GetAllCountries")]
        public async Task<IActionResult> GetAllCountries()
        {

            var lang = HttpContext.GetRequestedLanguage();
            return Ok(await _repoWrapper.RepoCountry.
                GetAllCountriesAsync(langCode:lang));
        }

        [HttpPost,Route("CreateCountry")]
        public async Task<IActionResult> CreateCountry([FromBody]string countryName)
        {
            var country = new TblCountry
            {
                CountryCode = "AU",
                TblCountryTrans = new List<TblCountryTran>()
                {
                    new TblCountryTran
                    {
                        LangCode = "en",
                        CountryName = countryName
                    }
                }
            };
          var inserted= await _repoWrapper.RepoCountry.AddCountryAsync(country);   
            return Ok(inserted);
        }


        [HttpGet, Route("GetCountry")]
        public async Task<IActionResult> GetCountry([FromQuery] Guid id)
        {

           // var lang = HttpContext.GetRequestedLanguage();
            return Ok(await _repoWrapper.RepoCountry.
                GetCountryAsync(id));
        }


        [HttpGet, Route("GetCountryLanguages")]
        public async Task<IActionResult> GetCountryLanguages([FromQuery] Guid id)
        {

            // var lang = HttpContext.GetRequestedLanguage();
            return Ok(await _repoWrapper.RepoCountry.
                GetCountrylangAsync(id));
        }

        [HttpDelete, Route("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry([FromQuery]Guid Id)
        {
           bool deleted = await _repoWrapper.RepoCountry.DeleteCountryAsync(Id);
            return Ok(deleted);
        }
    }
}
