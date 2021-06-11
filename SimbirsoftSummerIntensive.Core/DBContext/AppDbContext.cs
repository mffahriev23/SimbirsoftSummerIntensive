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
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>()
                        .Property(x => x.Created)
                        .HasDefaultValueSql("getdate()");
        }

        public DbSet<Resource> Resource { get; set; }
        public DbSet<StatisticField> StatisticField { get; set; }
    }
}
