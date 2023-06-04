using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Repository;

public class TryitterContext : DbContext
{
    public DbSet<Student>? Students {get; set;}
    public DbSet<Module>? Modules {get; set;}
    public DbSet<Post>? Posts {get; set;}

    public TryitterContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=tryitter_db;User=SA;Password=Password12!;");
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Post>()
        .HasKey(p => p.PostId);
      modelBuilder.Entity<Post>()
        .HasOne(b => b.Student)
        .WithMany(b => b.Posts)
        .HasForeignKey(b => b.StudentId);
      modelBuilder.Entity<Student>()
        .HasKey(s => s.StudentId);

    }

}