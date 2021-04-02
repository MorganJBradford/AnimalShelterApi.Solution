using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;


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
  }
}