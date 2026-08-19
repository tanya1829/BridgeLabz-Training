using Microsoft.EntityFrameworkCore;
using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.Repository
{
    // DbContext - represents session with database
    public class FundooDbContext : DbContext
    {
        // Constructor - options passed from Program.cs (connection string, provider)
        public FundooDbContext(DbContextOptions<FundooDbContext> options) : base(options)
        {
        }

        // DbSet - maps to Users table
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Email should be unique - prevents duplicate registrations
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
