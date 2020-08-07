using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PruebaApiSpa.Configuration;
using PruebaApiSpa.Web;

namespace PruebaApiSpa.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class PruebaApiSpaDbContextFactory : IDesignTimeDbContextFactory<PruebaApiSpaDbContext>
    {
        public PruebaApiSpaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PruebaApiSpaDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            PruebaApiSpaDbContextConfigurer.Configure(builder, configuration.GetConnectionString(PruebaApiSpaConsts.ConnectionStringName));

            return new PruebaApiSpaDbContext(builder.Options);
        }
    }
}
