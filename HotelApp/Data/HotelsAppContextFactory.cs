using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace HotelApp.Data
{
    public class HotelsAppContextFactory : IDesignTimeDbContextFactory<HotelsAppContext>
    {
        public HotelsAppContext CreateDbContext(string[] args)
        {
            string basePath = Directory.GetCurrentDirectory();
            Console.WriteLine($"Using base path: {basePath}"); // <-- Вывод пути в консоль

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<HotelsAppContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string is missing!");
            }

            optionsBuilder.UseSqlServer(connectionString);
            return new HotelsAppContext(optionsBuilder.Options);
        }
    }
}


