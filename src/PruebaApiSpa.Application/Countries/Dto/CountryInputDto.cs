using Abp.AutoMapper;
using PruebaApiSpa.Base;
using PruebaApiSpa.Domain;

namespace PruebaApiSpa.Countries.Dto
{
    [AutoMapTo(typeof(Country))]
    public class CountryInputDto : EntityBaseDto
    {
        public string ShortName { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string NumericCode { get; set; }
        public string LinkSubDivision { get; set; }
    }
}
