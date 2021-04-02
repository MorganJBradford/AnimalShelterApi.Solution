using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AnimalShelter.Controllers
{
  [Route("api/[conroller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;
    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }

    // GET: api/Animals
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> Get(string name, string species, string gender, int age)
    {
      var query = _db.Animals.AsQueryable();

      if (name != null)
      {
        query = query.Where(e => e.Name == name);
      }

      if (species != null)
      {
        query = query.Where(e => e.Species.ToString() == species);
      }

      if (gender != null)
      {
        query = query.Where(e => e.Gender.ToString() == gender);
      }

      if (age != 0)
      {
        query = query.Where(e => e.Age == age);
      }

      return await query.ToListAsync();
    }

    // api/Animals/2
    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      
      if (animal == null)
      {
        return NotFound();
      }

      return animal;
    }

    //Post: api/Animals
    [HttpPost]
    public async Task<ActionResult<Animal>> Post(Animal animal)
    {
      _db.Animals.Add(animal);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
    }

    [HttpDelete("id")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var animal = await _db.Animals.FindAsync(id);
      if (animal == null)
      {
        return NotFound();
      }

      _db.Animals.Remove(animal);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool AnimalExists(int id)
    {
      return _db.Animals.Any(e => e.AnimalId == id);
    }
  }
}