using Abp.AutoMapper;
using PruebaApiSpa.Base;
using PruebaApiSpa.Domain;

namespace PruebaApiSpa.Countries.Dto
{
    [AutoMapFrom(typeof(Country))]
    public class CountryDto : EntityBaseDto
    {
        public string ShortName { get; set; }
        public string Alpha2Code { get; set; }
        public string LinkSubDivision { get; set; }
        public int ProvincesCount { get; set; }
    }
}
