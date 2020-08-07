using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaApiSpa.Domain
{
    public class Country: Entity<long>
    {
        public string ShortName { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string NumericCode { get; set; }
        public string LinkSubDivision { get; set; }

        public virtual HashSet<Province> Provinces { get; set; } = new HashSet<Province>();
    }
}
