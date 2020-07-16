using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using WebAPI.Configuration;
using WebAPI.Web;

namespace WebAPI.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class WebAPIDbContextFactory : IDesignTimeDbContextFactory<WebAPIDbContext>
    {
        public WebAPIDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<WebAPIDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            WebAPIDbContextConfigurer.Configure(builder, configuration.GetConnectionString(WebAPIConsts.ConnectionStringName));

            return new WebAPIDbContext(builder.Options);
        }
    }
}
