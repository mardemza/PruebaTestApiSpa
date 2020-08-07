using Abp.Domain.Entities;

namespace PruebaApiSpa.Domain
{
    public class Province: Entity<long>
    {
        public string Code { get; set; }
        public string SubDivisionName { get; set; }

        public long CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}