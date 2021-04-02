using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
      : base(options)
      {
      }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
          new Animal { AnimalId = 1, Name = "Gizmo", Species = "Cat", Age = 7, Gender = "Female" },
          new Animal { AnimalId = 2, Name = "Gerry", Species = "Doge", Age = 7, Gender = "Male" },
          new Animal { AnimalId = 3, Name = "Geraldo", Species = "Doge", Age = 7, Gender = "Jerry" },
          new Animal { AnimalId = 4, Name = "Guillermo", Species = "Cat", Age = 7, Gender = "Terry" },
          new Animal { AnimalId = 5, Name = "Gizmo", Species = "Cat", Age = 7, Gender = "Berry" }
        );
    }
    public DbSet<Animal> Animals { get; set; }
  }
}