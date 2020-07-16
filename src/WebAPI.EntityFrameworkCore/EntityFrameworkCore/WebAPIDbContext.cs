using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using WebAPI.Authorization.Roles;
using WebAPI.Authorization.Users;
using WebAPI.MultiTenancy;
using WebAPI.Sabrina.barcodeScan;
using WebAPI.EntityMapper.invs;
using WebAPI.Sabrina.Conppr;
using WebAPI.Sabrina.Locations;
using WebAPI.Sabrina.Details;

namespace WebAPI.EntityFrameworkCore
{
    public class WebAPIDbContext : AbpZeroDbContext<Tenant, Role, User, WebAPIDbContext>
    {

        
        public   DbSet<Inv> Inv { get; set; }
        public DbSet<ConPpr> ConPprs { get; set; }
        public DbSet<Locations> Location { get; set; }


        public DbSet<Details> Detailss { get; set; }


        public WebAPIDbContext(DbContextOptions<WebAPIDbContext> options)
            : base(options)
        {
        }
       
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new invCfg());
        }
        */

    }
}
