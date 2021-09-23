using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PhoneBook.Data.Models
{
    public partial class phonebookContext : DbContext
    {
        public phonebookContext()
        {
        }

        public phonebookContext(DbContextOptions<phonebookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<PhoneBook> PhoneBooks { get; set; }
        public virtual DbSet<PhoneBookEntry> PhoneBookEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=phonebook;Username=postgres;Password=pwd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_South Africa.1252");

            modelBuilder.Entity<Entry>(entity =>
            {
                entity.ToTable("Entry");

                entity.HasIndex(e => e.PhoneNumber, "Entry_PhoneNumber_UX")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PhoneBook>(entity =>
            {
                entity.ToTable("PhoneBook");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<PhoneBookEntry>(entity =>
            {
                entity.ToTable("PhoneBookEntry");

                entity.HasOne(d => d.Entry)
                    .WithMany(p => p.PhoneBookEntries)
                    .HasForeignKey(d => d.EntryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PhoneBookEntry_Entry_PK");

                entity.HasOne(d => d.PhoneBook)
                    .WithMany(p => p.PhoneBookEntries)
                    .HasForeignKey(d => d.PhoneBookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PhoneBookEntry_PhoneBook_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
