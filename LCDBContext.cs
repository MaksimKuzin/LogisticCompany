﻿using LogisticCompany.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LogisticCompany
{
    public class LCDBContext : DbContext
    {
        public LCDBContext(DbContextOptions options) : base(options)
        {
        }

        public LCDBContext()
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Recepient> Recepients { get; set; }
        public virtual DbSet<Tranport> Transports { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Courier> Couriers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=LogisticCompany;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true", x => x.UseDateOnlyTimeOnly());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Navigation(o => o.Recepient)
                .AutoInclude();

            modelBuilder.Entity<Order>()
                .Navigation(o => o.Courier)
                .AutoInclude();

            modelBuilder.Entity<Order>()
                .Navigation(o => o.Transport)
                .AutoInclude();

            modelBuilder.Entity<Order>()
                .Navigation(o => o.Warehouses)
                .AutoInclude();

            modelBuilder.Entity<Order>()
                .Property(w => w.RecepientId)
                .IsRequired(false);

            modelBuilder.Entity<Order>()
                .Property(w => w.TransportId)
                .IsRequired(false);

            modelBuilder.Entity<Order>()
                .Property(w => w.CourierId)
                .IsRequired(false);

            modelBuilder.Entity<Order>()
                .Property(o => o.Price)
                .HasDefaultValue(100);

            modelBuilder.Entity<Courier>()
                .HasIndex(c => c.FIO);

        }
        public void ApplyDiscountToOrder(int orderId)
        {
            Database.ExecuteSqlRaw("EXEC ApplyDiscountToOrder @OrderId", new SqlParameter("@OrderId", orderId));
        }
    }
}
