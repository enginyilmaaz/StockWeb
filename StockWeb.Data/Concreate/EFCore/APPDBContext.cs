using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockWeb.Data.Entity;

namespace StockWeb.Data.Concreate.EFCore
{
    public class APPDBContext : IdentityDbContext<Users>
    {
       

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Sellings> Sellings { get; set; }
        public DbSet<Purchases> Purchases { get; set; }


        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //            .AddJsonFile("appsettings.json")
        //            .Build();
        //        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           var ConnString= "Data Source = DESKTOP-L0539F8\\SQLEXPRESS; Database = StockWeb; Uid = sa;Pwd = 19951992";
            optionsBuilder.UseSqlServer(ConnString);
        }

    }

}
