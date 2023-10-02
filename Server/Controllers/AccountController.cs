using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static TaskManagerSolution.Client.Pages.Auth.Register;
using TaskManagerSolution.Shared.Models;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        Console.WriteLine($"Received model: Username={model.Username}, Email={model.Email}, Password={model.Password}");

        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return Ok(new { Message = "Registration successful" });
        }
        else
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine($"Error: {error.Description}");
            }
            return BadRequest(result.Errors);
        }
    }

    // In your AccountController on the server
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            // Generate token and return (depends on your authentication scheme)
            return Ok(new { Token = "Some JWT token or similar" });
        }
        return Unauthorized();
    }
}
