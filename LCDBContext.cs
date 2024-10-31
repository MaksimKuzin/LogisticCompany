using LogisticCompany.Models;
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
        public virtual DbSet<Tranport> Tranports { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Courier> Couriers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=LogisticCompany;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true", x =>x.UseDateOnlyTimeOnly());
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
                .Navigation(o => o.Tranport)
                .AutoInclude();           
            
            modelBuilder.Entity<Order>()
                .Navigation(o => o.Warehouses)
                .AutoInclude();            

            // Повторите для других сущностей, если требуется
        }
    }
}
