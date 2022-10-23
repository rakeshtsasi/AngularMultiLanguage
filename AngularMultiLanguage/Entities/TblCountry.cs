namespace AngularMultiLanguage.Entities
{
    public class TblCountry : BaseEntity, IAuditable
    {
        public TblCountry()
        {
            TblCountryTrans = new HashSet<TblCountryTran>();
        }
        public string CountryCode { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public virtual ICollection<TblCountryTran>? TblCountryTrans { get; set; }
    }
}