using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

using StronglyTypedKeyDemo2.Models;

namespace StronglyTypedKeyDemo2.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
    {


    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("name=DefaultConnection");
        }
#if DEBUG
        optionsBuilder.EnableSensitiveDataLogging();
#endif
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.Id)
            .HasColumnType("int");

            entity.Property(e => e.Id)
            .ValueGeneratedOnAdd()
            .HasConversion(id => id.Value, value => new AuthorId(value));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.LastName)
              .IsRequired()
              .HasMaxLength(100);

            entity.HasMany(e => e.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Book>(static entity =>
        {
            entity.Property(e => e.Id)
            .HasColumnType("uniqueidentifier");

            entity.Property(e => e.AuthorId)
           .HasColumnType("int");

            entity.Property(e => e.Id)
             .ValueGeneratedOnAdd()
             //.HasValueGenerator<GuidValueGenerator>()
             .HasConversion(id => id.Value, value => new BookId(value));

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasConversion(id => id.Value, value => new BookId(value));

            entity.Property(e => e.AuthorId)
                .HasConversion(id => id.Value, value => new AuthorId(value));
        });
    }
}
