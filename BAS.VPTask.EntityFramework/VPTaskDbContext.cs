using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAS.VPTask.Core.Entities;
using BAS.VPTask.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BAS.VPTask.EntityFramework
{
    public class VPTaskDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<Customer> Customers { get; set; }
        public DbSet<ItemStock> ItemStocks { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Order> Orders { get; set; }

        public VPTaskDbContext(DbContextOptions<VPTaskDbContext> options, IConfiguration configuration)
            :base(options)
        {
            _config = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ItemStockConfiguration());
            modelBuilder.ApplyConfiguration(new ItemOrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["DefaultConnectionString"]);
        }
    }
}