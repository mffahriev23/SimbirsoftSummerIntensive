using Microsoft.EntityFrameworkCore;
using SimbirsoftSummerIntensive.Core.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimbirsoftSummerIntensive.Core.DBContext
{
    public class AppDbContext : DbContext
    {
        private string _connectionString;

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-73G6TMG\\SQLEXPRESS;Database=Simbirsoft;Trusted_Connection=True;MultipleActiveResultSets=true");
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                        .Property(x => x.Created)
                        .HasDefaultValue(DateTimeOffset.UtcNow);
        }

        public DbSet<Resource> Resource { get; set; }
        public DbSet<StatisticField> StatisticField { get; set; }
    }
}
