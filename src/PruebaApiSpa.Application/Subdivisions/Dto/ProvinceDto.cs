using Abp.AutoMapper;
using PruebaApiSpa.Base;
using PruebaApiSpa.Domain;

namespace PruebaApiSpa.Subdivisions.Dto
{
    [AutoMapFrom(typeof(Province))]
    public class ProvinceDto : EntityBaseDto
    {
        public string Code { get; set; }
        public string SubDivisionName { get; set; }
    }
}
