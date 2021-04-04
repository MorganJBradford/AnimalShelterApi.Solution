using AnimalShelter.Configuration;
using AnimalShelter.Models.DTOs.Requests;
using AnimalShelter.Models.DTOs.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthManagementController : ControllerBase
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtConfig _jwtConfig;

    public AuthManagementController(UserManager<IdentityUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
    {
      _userManager = userManager;
      _jwtConfig = optionsMonitor.CurrentValue;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto user)
    {
      if (ModelState.IsValid)
      {
        var existingUser = await _userManager.FindByEmailAsync(user.Email);

        if(existingUser != null)
        {
          return BadRequest(new RegistrationResponse()
          {
            Errors = new List<string>()
            {
              "Email already in use"
            },
            Success = false
          });
        }

        var newUser = new IdentityUser() { Email = user.Email, UserName = user.Email };
        var isCreated = await _userManager.CreateAsync(newUser, user.Password);

        if(isCreated.Succeeded)
        {

        }
        else
        {
          return BadRequest(new RegistrationResponse()
          {
            Errors = isCreated.Errors.Select(x => x.Description).ToList(),            
            Success = false
          });
        }
      }

      return BadRequest(new RegistrationResponse()
      {
        Errors = new List<string>()
        {
          "Invalid payload"
        },
        Success = false
      });
    }


  }
}