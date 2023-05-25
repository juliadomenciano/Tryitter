using Microsoft.EntityFrameworkCore;
using tryitter.Models;

namespace tryitter.Repository;

public class TryitterContext : DbContext
{
    public DbSet<Student>? Students {get; set;}
    public DbSet<Post>? Posts {get; set;}
    public DbSet<Module>? Modules {get; set;}
    

    public TryitterContext()
    {
    }
    public TryitterContext(DbContextOptions<TryitterContext> options)
     : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=tryitter_db;User=SA;Password=Password12!;");
    }

}