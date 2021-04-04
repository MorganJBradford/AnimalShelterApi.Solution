using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : IdentityDbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
      : base(options)
      {
      }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
          new Animal { AnimalId = 1, Name = "Gizmo", Species = "Cat", Age = 7, Gender = "F" },
          new Animal { AnimalId = 2, Name = "Gerry", Species = "Dog", Age = 7, Gender = "M" },
          new Animal { AnimalId = 3, Name = "Geraldo", Species = "Dog", Age = 7, Gender = "M" },
          new Animal { AnimalId = 4, Name = "Guillermo", Species = "Cat", Age = 7, Gender = "F" },
          new Animal { AnimalId = 5, Name = "Gizmo", Species = "Cat", Age = 7, Gender = "F" }
        );
      base.OnModelCreating(builder);
    }
    public DbSet<Animal> Animals { get; set; }
  }
}