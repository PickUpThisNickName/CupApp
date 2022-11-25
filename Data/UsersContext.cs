using CupApplication.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CupApplication.Data
{
    public class UsersContext : IdentityDbContext<User>
    {

        public UsersContext(DbContextOptions<UsersContext> options)
    : base(options)
        {
        }

        public DbSet<User> AspNetUsers { get; set; }
        public DbSet<WorkingSession> DB_WorkingSession { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WorkingSession>().HasOne(b => b.GroupObj).WithMany(g => g.Sessions);
        }
    }
}
