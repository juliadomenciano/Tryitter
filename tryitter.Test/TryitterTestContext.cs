using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using tryitter.Models;
using tryitter.Repository;

namespace tryitter.Test;

public class TestTryitterContext<TEntryPoint> : WebApplicationFactory<Program> where TEntryPoint : Program
{

  protected override void ConfigureWebHost(IWebHostBuilder builder)
  {
    builder.ConfigureServices(services =>
    {
      var descriptor = services.SingleOrDefault(
              d => d.ServiceType ==
                  typeof(DbContextOptions<TryitterContext>));
      if (descriptor != null)
        services.Remove(descriptor);
      services.AddDbContext<TryitterContext>(options =>
          {
            options.UseInMemoryDatabase("db");
          });
      var sp = services.BuildServiceProvider();
      using (var scope = sp.CreateScope())
      using (var appContext = scope.ServiceProvider.GetRequiredService<TryitterContext>())
      {
        try
        {

          appContext.Database.EnsureDeleted();

          appContext.Database.EnsureCreated();

          appContext.Modules.AddRange(
            new Module { Name = "Module1" },
            new Module { Name = "Module2" }
            );

          appContext.Students.AddRange(
            new Student { Name = "Student1", Email = "student1@email.com", Password = "123456", Status = "On", ModuleId = 1 },
            new Student { Name = "Student2", Email = "student2@email.com", Password = "23456", Status = "On", ModuleId = 1 },
            new Student { Name = "Student3", Email = "student3@email.com", Password = "123456", Status = "On", ModuleId = 1 },
            new Student { Name = "Student4", Email = "student4@email.com", Password = "123456", Status = "On", ModuleId = 1 }
            );

          appContext.Posts.AddRange(
            new Post { Title = "Title 1", Text = "Text 1", CreatedAt = new DateTime(2023, 1, 1, 1, 1, 0), UpdatedAt = new DateTime(2023, 1, 1, 1, 1, 0), StudentId = 1 },
            new Post { Title = "Title 2", Text = "Text 2", CreatedAt = new DateTime(2023, 1, 1, 1, 1, 0), UpdatedAt = new DateTime(2023, 1, 1, 1, 1, 0), StudentId = 1 },
            new Post { Title = "Title 3", Text = "Text 3", CreatedAt = new DateTime(2023, 1, 1, 1, 1, 0), UpdatedAt = new DateTime(2023, 1, 1, 1, 1, 0), StudentId = 2 },
            new Post { Title = "Title 4", Text = "Text 4", CreatedAt = new DateTime(2023, 1, 1, 1, 1, 0), UpdatedAt = new DateTime(2023, 1, 1, 1, 1, 0), StudentId = 3 },
            new Post { Title = "Title 5", Text = "Text 5", CreatedAt = new DateTime(2023, 1, 1, 1, 1, 0), UpdatedAt = new DateTime(2023, 1, 1, 1, 1, 0), StudentId = 4 }
          );
          appContext.SaveChanges();

        }
        catch (Exception e)
        {
          throw e;
        }
      }
    });
  }
}