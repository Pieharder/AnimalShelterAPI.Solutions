using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options)
        : base(options)
    {

    }

    public DbSet<Animal> Animals { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
				.HasData(
					new Animal { AnimalId = 1, Name = "Tardar Sauce", Species = "Ragdoll Cat", Age = 7, Gender = "Female" },
					new Animal { AnimalId = 2, Name = "Huginn", Species = "Bombay Cat", Age = 3, Gender = "Female" },
					new Animal { AnimalId = 3, Name = "Muninn", Species = "Bombay Cat", Age = 3, Gender = "Male" },
					new Animal { AnimalId = 4, Name = "Odin", Species = "Labrador Retriever", Age = 4, Gender = "Male" },
					new Animal { AnimalId = 5, Name = "Boncuk", Species = "Tabby Cat", Age = 8, Gender = "Female" }
				);
    }
  }
}