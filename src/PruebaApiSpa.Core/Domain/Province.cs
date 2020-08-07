using Abp.Domain.Entities;

namespace PruebaApiSpa.Domain
{
    public class Province: Entity<long>
    {
        public string Code { get; set; }
        public string SubDivisionName { get; set; }        
    }
}