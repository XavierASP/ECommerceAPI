using ECommerceAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ECommerceAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
        public DatabaseContext CreateDbContext(string[] args)
        {
            //IConfigurationRoot configuration = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../ECommerceAPI/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            //var connectionString = configuration.GetConnectionString("ECommerceConnection");
            builder.UseSqlServer("Server=DESKTOP-U038P2P\\SQLEXPRESS;Database=ECommerce;user id=ecommerce;password=Test@123;");
            return new DatabaseContext(builder.Options);
        }
    }
}
