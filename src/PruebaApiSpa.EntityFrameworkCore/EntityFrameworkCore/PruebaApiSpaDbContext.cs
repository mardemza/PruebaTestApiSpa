using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using PruebaApiSpa.Authorization.Roles;
using PruebaApiSpa.Authorization.Users;
using PruebaApiSpa.MultiTenancy;

namespace PruebaApiSpa.EntityFrameworkCore
{
    public class PruebaApiSpaDbContext : AbpZeroDbContext<Tenant, Role, User, PruebaApiSpaDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public PruebaApiSpaDbContext(DbContextOptions<PruebaApiSpaDbContext> options)
            : base(options)
        {
        }
    }
}
