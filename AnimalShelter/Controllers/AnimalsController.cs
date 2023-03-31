using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> Get(string Breed, string Name, int Age, string Color, string Gender)
    {
      IQueryable<Animal> query = _db.Animals.AsQueryable();

      if (Breed != null)
      {
        query = query.Where(entry => entry.Breed == Breed);
      }

      if (Name != null)
      {
        query = query.Where(entry => entry.Name == Name);
      }

      if (Age != 0)
      {
        query = query.Where(entry => entry.Age == Age);
      }

      if (Color != null)
      {
        query = query.Where(entry => entry.Color == Color);
      }

      if (Gender != null)
      {
        query = query.Where(entry => entry.Gender == Gender);
      }



      return await _db.Animals.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      Animal animal = await _db.Animals.FindAsync(id);

      if (animal == null)
      {
        return NotFound();
      }

      return animal;
    }

    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Animal animal)
    {
      if (id != animal.AnimalId)
      {
        return BadRequest();
      }

      _db.Animals.Update(animal);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AnimalExists(id))
        {
          return NotFound();
        }
        else {
          throw;
        }
      }
        return NoContent();
      }

      private bool AnimalExists(int id)
      {
        return _db.Animals.Any(obj => obj.AnimalId == id);
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteAnimal(int id)
      {
        Animal animal = await _db.Animals.FindAsync(id);
        if(animal == null)
        {
          return NotFound();
        }

        _db.Animals.Remove(animal);
        await _db.SaveChangesAsync();

        return NoContent();
      }
    }
  }