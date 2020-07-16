using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Configuration;
using WebAPI.Sabrina.Conppr;
using WebAPI.Web;

namespace WebAPI.EntityFrameworkCore
{
   public class XMAPIDbContext :DbContext
    {
         
        public DbSet<ConPpr> ConPprs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //     var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentXMDBRootFolder());
            optionsBuilder.UseMySql(configuration.GetConnectionString(WebAPIConsts.ConnectionStringName));
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
