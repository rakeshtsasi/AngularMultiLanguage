using System.ComponentModel.DataAnnotations;

namespace AngularMultiLanguage.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
