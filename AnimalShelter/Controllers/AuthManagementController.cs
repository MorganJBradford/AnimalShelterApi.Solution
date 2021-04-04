using AnimalShelter.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthManagementController : ControllerBase
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtConfig _jwtConfig;
  }
}