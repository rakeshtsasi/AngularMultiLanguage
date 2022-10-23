using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularMultiLanguage.Entities
{
    public class TblAppLangMaster
    {
        [Key]
        [Column(TypeName ="varchar(2)")]
        public string LangCode { get; set; } = null!;
        [Column(TypeName ="nvarchar(70)")]
        public string LangName { get; set; } = null!;
    }
}
