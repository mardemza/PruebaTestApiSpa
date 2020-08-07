using PruebaApiSpa.Domain;
using System;
using System.Linq;

namespace PruebaApiSpa.EntityFrameworkCore.Seed
{
    internal class CreateCountryProvinceBuilder
    {
        private PruebaApiSpaDbContext context;

        public CreateCountryProvinceBuilder(PruebaApiSpaDbContext context)
        {
            this.context = context;
        }

        public void Create()
        {
            #region Andorra

            // Country Andorra
            var country1 = context.Countries.FirstOrDefault(x => x.ShortName == "Andorra");
            if (country1 == null)
            {
                country1 = new Country
                {
                    ShortName = "Andorra",
                    Alpha2Code = "AD",
                    Alpha3Code = "AND",
                    NumericCode = "020",
                    LinkSubDivision = "https://en.wikipedia.org/wiki/ISO_3166-2:AD"
                };
                context.Countries.Add(country1);
                context.SaveChanges();
            }

            // Province Andorra la Vella
            var province1Andorra = context.Provinces.FirstOrDefault(x => x.SubDivisionName == "Andorra la Vella");
            if (province1Andorra == null)
            {
                province1Andorra = new Province
                {
                    SubDivisionName = "Andorra la Vella",
                    Code = "AD-07",
                    CountryId = country1.Id
                };
                context.Provinces.Add(province1Andorra);
                context.SaveChanges();
            }

            // Province Canillo
            var province2Andorra = context.Provinces.FirstOrDefault(x => x.SubDivisionName == "Canillo");
            if (province2Andorra == null)
            {
                province2Andorra = new Province
                {
                    SubDivisionName = "Canillo",
                    Code = "AD-02",
                    CountryId = country1.Id
                };
                context.Provinces.Add(province2Andorra);
                context.SaveChanges();
            }

            // Province Encamp
            var province3Andorra = context.Provinces.FirstOrDefault(x => x.SubDivisionName == "Encamp");
            if (province3Andorra == null)
            {
                province3Andorra = new Province
                {
                    SubDivisionName = "Encamp",
                    Code = "AD-03",
                    CountryId = country1.Id
                };
                context.Provinces.Add(province3Andorra);
                context.SaveChanges();
            }

            // Province Escaldes-Engordany
            var province4Andorra = context.Provinces.FirstOrDefault(x => x.SubDivisionName == "Escaldes-Engordany");
            if (province4Andorra == null)
            {
                province4Andorra = new Province
                {
                    SubDivisionName = "Escaldes-Engordany",
                    Code = "AD-08",
                    CountryId = country1.Id
                };
                context.Provinces.Add(province4Andorra);
                context.SaveChanges();
            }

            // Province La Massana
            var province5Andorra = context.Provinces.FirstOrDefault(x => x.SubDivisionName == "La Massana");
            if (province5Andorra == null)
            {
                province5Andorra = new Province
                {
                    SubDivisionName = "La Massana",
                    Code = "AD-04",
                    CountryId = country1.Id
                };
                context.Provinces.Add(province5Andorra);
                context.SaveChanges();
            }

            // Province Ordino
            var province6Andorra = context.Provinces.FirstOrDefault(x => x.SubDivisionName == "Ordino");
            if (province6Andorra == null)
            {
                province6Andorra = new Province
                {
                    SubDivisionName = "Ordino",
                    Code = "AD-05",
                    CountryId = country1.Id
                };
                context.Provinces.Add(province6Andorra);
                context.SaveChanges();
            }

            // Province Sant Julià de Lòria
            var province7Andorra = context.Provinces.FirstOrDefault(x => x.SubDivisionName == "Sant Julià de Lòria");
            if (province7Andorra == null)
            {
                province7Andorra = new Province
                {
                    SubDivisionName = "Sant Julià de Lòria",
                    Code = "AD-06",
                    CountryId = country1.Id
                };
                context.Provinces.Add(province7Andorra);
                context.SaveChanges();
            }

            #endregion

            #region Argentina

            // Country Andorra
            var country2 = context.Countries.FirstOrDefault(x => x.ShortName == "Argentina");
            if (country2 == null)
            {
                country2 = new Country
                {
                    ShortName = "Argentina",
                    Alpha2Code = "AR",
                    Alpha3Code = "ARG",
                    NumericCode = "032",
                    LinkSubDivision = "https://en.wikipedia.org/wiki/ISO_3166-2:AR"
                };
                context.Countries.Add(country2);
                context.SaveChanges();
            }

            // Province Buenos Aires
            var province1Argentina = context.Provinces.FirstOrDefault(x => x.SubDivisionName == "Buenos Aires");
            if (province1Argentina == null)
            {
                province1Argentina = new Province
                {
                    SubDivisionName = "Buenos Aires",
                    Code = "AR-B",
                    CountryId = country2.Id
                };
                context.Provinces.Add(province1Argentina);
                context.SaveChanges();
            }

            // Province Catamarca
            var province2Argentina = context.Provinces.FirstOrDefault(x => x.SubDivisionName == "Catamarca");
            if (province2Argentina == null)
            {
                province2Argentina = new Province
                {
                    SubDivisionName = "Catamarca",
                    Code = "AR-K",
                    CountryId = country2.Id
                };
                context.Provinces.Add(province2Argentina);
                context.SaveChanges();
            }

            // Province Mendoza
            var province3Argentina = context.Provinces.FirstOrDefault(x => x.SubDivisionName == "Mendoza");
            if (province3Argentina == null)
            {
                province3Argentina = new Province
                {
                    SubDivisionName = "Mendoza",
                    Code = "AR-M",
                    CountryId = country2.Id
                };
                context.Provinces.Add(province3Argentina);
                context.SaveChanges();
            }

            // Province San Luis
            var province4Argentina = context.Provinces.FirstOrDefault(x => x.SubDivisionName == "San Luis");
            if (province4Argentina == null)
            {
                province4Argentina = new Province
                {
                    SubDivisionName = "San Luis",
                    Code = "AR-D",
                    CountryId = country2.Id
                };
                context.Provinces.Add(province4Argentina);
                context.SaveChanges();
            }            

            #endregion
        }
    }
}