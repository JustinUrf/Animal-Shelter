using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public DbSet<Animal> Animals { get; set; }
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
      .HasData(
        new Animal { AnimalId = 1, Breed = "Dog", Name = "Sammy", Age = 3, Color = "Brownish Mix", Gender = "Male" },
        new Animal { AnimalId = 2, Breed = "Cat", Name = "Turner", Age = 2, Color = "Blone", Gender = "Female" },
        new Animal { AnimalId = 3, Breed = "Cat", Name = "Princess", Age = 6, Color = "Black", Gender = "Female" },
        new Animal { AnimalId = 4, Breed = "Dog", Name = "George", Age = 4, Color = "White", Gender = "Male" },
        new Animal { AnimalId = 5, Breed = "Dog", Name = "Epic", Age = 7, Color = "Brown", Gender = "Female" }

      );
    }
  }
}