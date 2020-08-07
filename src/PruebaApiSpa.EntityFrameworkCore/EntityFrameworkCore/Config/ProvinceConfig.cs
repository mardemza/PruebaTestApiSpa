using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaApiSpa.Domain;

namespace PruebaApiSpa.EntityFrameworkCore.Config
{
    public class ProvinceConfig : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Provinces");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.SubDivisionName);
            builder.HasIndex(x => x.Code);

            builder.HasOne(x => x.Country)
                    .WithMany(x => x.Provinces)
                    .HasForeignKey(x => x.CountryId)
                    .IsRequired();
        }
    }
}