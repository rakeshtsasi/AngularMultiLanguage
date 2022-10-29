using System.ComponentModel.DataAnnotations.Schema;

namespace AngularMultiLanguage.Entities
{
    public class TblCountryTran:BaseEntity
    {
        public Guid CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual TblCountry TblCountry { get; set; } = null!;
        public string LangCode { get; set; } = null!;
        [ForeignKey(nameof(LangCode))]
        public virtual TblAppLangMaster TblAppLangMaster { get; set; } = null!;
        [Column(TypeName ="NVARCHAR(150)")]
        public string? CountryName { get; set; }
    }
}
