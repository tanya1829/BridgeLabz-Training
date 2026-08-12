using Microsoft.EntityFrameworkCore;
using ContactsApp.Models;

namespace ContactsApp.Repo
{
    // EF Core DbContext - manages connection and mapping to SQL Server
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToTable("Contact");
        }
    }
}