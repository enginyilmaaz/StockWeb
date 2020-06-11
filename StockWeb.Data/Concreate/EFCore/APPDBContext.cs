using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
            string ConnString = "Data Source = engintest2020.database.windows.net; Database = StockWeb; Uid = engin;Pwd =_StockWeb";
            optionsBuilder.UseSqlServer(ConnString);
        }

    }

}
