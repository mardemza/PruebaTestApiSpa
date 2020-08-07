using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace PruebaApiSpa.EntityFrameworkCore
{
    public static class PruebaApiSpaDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<PruebaApiSpaDbContext> builder, string connectionString)
        {
            builder.UseSqlite(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<PruebaApiSpaDbContext> builder, DbConnection connection)
        {            
            builder.UseSqlite(connection);
        }
    }
}
