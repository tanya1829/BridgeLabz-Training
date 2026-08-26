using Microsoft.EntityFrameworkCore;
using FundooNotesApp.ModelLayer.Entities;

namespace FundooNotesApp.Repository
{
    public class FundooDbContext : DbContext
    {
        public FundooDbContext(DbContextOptions<FundooDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }              // naya
        public DbSet<NoteTag> NoteTags { get; set; }       // naya - join table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<NoteTag>()
    .HasOne<Tag>()
    .WithMany()
    .HasForeignKey(nt => nt.TagId)
    .OnDelete(DeleteBehavior.NoAction);

            // NoteTag - composite primary key (NoteId + TagId together must be unique)
            modelBuilder.Entity<NoteTag>()
                .HasKey(nt => new { nt.NoteId, nt.TagId });

            // NoteTag -> Note relationship
            modelBuilder.Entity<NoteTag>()
                .HasOne<Note>()
                .WithMany()
                .HasForeignKey(nt => nt.NoteId)
                .OnDelete(DeleteBehavior.Cascade);

            // NoteTag -> Tag relationship
            modelBuilder.Entity<NoteTag>()
                .HasOne<Tag>()
                .WithMany()
                .HasForeignKey(nt => nt.TagId)
                .OnDelete(DeleteBehavior.Cascade);

            // Tag -> User relationship
            modelBuilder.Entity<Tag>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}