using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library.Models
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Copy> Copy { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Library;Username=postgres;Password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Isbn);
                entity.Property(e => e.ID).ValueGeneratedOnAdd();

                entity.ToTable("book", "lib");

                entity.Property(e => e.Isbn)
                    .HasColumnName("isbn")
                    .HasColumnType("character(13)")
                    .IsRequired();

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasColumnName("author")
                    .HasColumnType("character varying(30)");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying(1000)");

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasColumnName("genre")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.Pages).HasColumnName("pages");

                entity.Property(e => e.Publisher)
                    .IsRequired()
                    .HasColumnName("publisher")
                    .HasColumnType("character varying(20)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("character varying(50)");
            });

            modelBuilder.Entity<Copy>(entity =>
            {
                entity.ToTable("copy", "lib");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("isbn")
                    .HasColumnType("character(13)");

                entity.Property(e => e.Libuser).HasColumnName("libuser");

                entity.Property(e => e.Return)
                    .HasColumnName("return")
                    .HasColumnType("date");

                entity.Property(e => e.Taken)
                    .HasColumnName("taken")
                    .HasColumnType("date");

                entity.HasOne(d => d.IsbnNavigation)
                    .WithMany(p => p.Copy)
                    .HasForeignKey(d => d.Isbn)
                    .HasConstraintName("tobook");

                entity.HasOne(d => d.LibuserNavigation)
                    .WithMany(p => p.Copy)
                    .HasForeignKey(d => d.Libuser)
                    .HasConstraintName("touser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "lib");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Identitycode)
                    .IsRequired()
                    .HasColumnName("identitycode")
                    .HasColumnType("character(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("character varying(30)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");
            });
        }
    }
}
