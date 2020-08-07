using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using PruebaApiSpa.Authorization.Roles;
using PruebaApiSpa.Authorization.Users;
using PruebaApiSpa.MultiTenancy;
using PruebaApiSpa.Domain;
using PruebaApiSpa.EntityFrameworkCore.Config;

namespace PruebaApiSpa.EntityFrameworkCore
{
    public class PruebaApiSpaDbContext : AbpZeroDbContext<Tenant, Role, User, PruebaApiSpaDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public PruebaApiSpaDbContext(DbContextOptions<PruebaApiSpaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryConfig());
            modelBuilder.ApplyConfiguration(new ProvinceConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
