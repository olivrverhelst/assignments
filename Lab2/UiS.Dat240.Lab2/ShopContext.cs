using Microsoft.EntityFrameworkCore;
using System.IO;
using System;

namespace UiS.Dat240.Lab2
{
    // This class should inherit from the EntityFramework DbContext

    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Combine(path, "shop.db");
        }
        public DbSet<FoodItem> FoodItems { get; set; }

        public string DbPath { get; private set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
            options.LogTo(Console.WriteLine);
            options.EnableSensitiveDataLogging();
        }
    }


}