using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaApiSpa.Domain;

namespace PruebaApiSpa.EntityFrameworkCore.Config
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.ShortName);
            builder.HasIndex(x => x.Alpha2Code);
        }
    }
}