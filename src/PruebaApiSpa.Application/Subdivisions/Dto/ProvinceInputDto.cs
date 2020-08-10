using Abp.AutoMapper;
using PruebaApiSpa.Base;
using PruebaApiSpa.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaApiSpa.Subdivisions.Dto
{
    [AutoMap(typeof(Province))]
    public class ProvinceInputDto: EntityBaseDto
    {
        public string Code { get; set; }
        public string SubDivisionName { get; set; }
        public long CountryId { get; set; }
    }
}
