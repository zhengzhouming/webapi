using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.EntityFrameworkCore
{
    public static class WebAPIDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<WebAPIDbContext> builder, string connectionString)
        {
            // builder.UseSqlServer(connectionString);
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<WebAPIDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection);
        }
    }
}
