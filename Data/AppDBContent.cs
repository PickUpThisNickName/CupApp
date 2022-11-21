using CupApplication.Data.Models;
using Microsoft.EntityFrameworkCore;
using CupApplication.Data.Models;

namespace CupApplication.Data
{
    public class AppDBContent:DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options)
    : base(options)
        {
            Database.EnsureCreated();
        }

        

        public DbSet<Beneficiaries> DB_Beneficiaries { get; set; }
        public DbSet<BenefitType> DB_BenefitType { get; set; }
        public DbSet<Drinks> DB_Drinks { get; set; }
        public DbSet<Drinks_leftovers> DB_Drinks_leftovers { get; set; }
        public DbSet<Products> DB_Products { get; set; }
        public DbSet<WorkingSession> DB_WorkingSession { get; set; }
        public DbSet<Sales> DB_Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Beneficiaries>().HasOne(b => b.GroupObj).WithMany(g => g.Persons);
        }

    }
}
