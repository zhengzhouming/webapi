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
           


            /*
              services.AddDbContextPool<ApplicationDbContext>( 
            options => options.UseMySql("Server=localhost;Database=ef;User=root;Password=123456;",

                mySqlOptions =>
                {
                    mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql)
                    .EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null); 
                }
            ));

            */

        }

        public static void Configure(DbContextOptionsBuilder<WebAPIDbContext> builder, DbConnection connection)
        {
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection);
        }
    }
}
