using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CorePassword.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> opts):base(opts)
        {
            
        }

        public DbSet<WebsitePassword> WebsitePassword { get; set; }
        public DbSet<WebsitePasswordHistory> WebsitePasswordHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WebsitePassword>()
                .HasMany(e => e.PasswordHistories)
                .WithOne(e => e.WebsitePassword)
                .HasForeignKey(e => e.WebsitePasswordId)
                .OnDelete(DeleteBehavior.ClientCascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}