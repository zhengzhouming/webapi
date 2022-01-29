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
using WebAPI.Sabrina.Countrecei;
using WebAPI.Sabrina.Invrecei;
using WebAPI.Sabrina.MesDept;
using WebAPI.Sabrina.MesWorkTagScan;
using WebAPI.Sabrina.MesWorkTagScanReceipt;
using WebAPI.Sabrina.Recei;
using WebAPI.Sabrina.Users;

namespace WebAPI.EntityFrameworkCore
{
    public class WebAPIDbContext : AbpZeroDbContext<Tenant, Role, User, WebAPIDbContext>
    {

        
        public   DbSet<Inv> Inv { get; set; }
        public DbSet<ConPpr> ConPprs { get; set; } 
        public DbSet<CONDetails> Detailss { get; set; }
        public DbSet<Countrecei> CountReceis { get; set; }
        public DbSet<Invrecei> Invreceis { get; set; }
        public DbSet<Locations> Location { get; set; }
        public DbSet<MesDept> MesDepts { get; set; }
        public DbSet<MesWorkTagScan> MesWorkTagScans { get; set; }
        public DbSet<MesWorkTagScanReceipt> MesWorkTagScanReceipts { get; set; }
        public DbSet<Recei> Receis { get; set; }
        public DbSet<MesUser> MesUsers { get; set; }

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
