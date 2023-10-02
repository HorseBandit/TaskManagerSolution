using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static TaskManagerSolution.Client.Pages.Auth.Register;
using TaskManagerSolution.Shared.Models;
using Newtonsoft.Json;
using TaskManagerSolution.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;
    public AccountController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
        var connStr = _context.Database.GetDbConnection().ConnectionString;
        Console.WriteLine("Connection String: " + connStr);
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
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        // TODO: Validate the model
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid model");
        }

        // TODO: Generate a salt and hash the password
        var salt = GenerateSalt();
        var hashedPassword = HashPassword(model.Password, salt);

        // TODO: Create the user
        var user = new User
        {
            Username = model.Username,
            Email = model.Email
        };

        // Add to Users table
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // Create user credentials
        var userCredential = new UserCredentials
        {
            UserId = user.Id,
            Username = user.Username,
            Email = user.Email,
            PasswordHash = hashedPassword,
            Salt = salt
        };

        // Add to UserCredentials table
        _context.UserCredentials.Add(userCredential);
        await _context.SaveChangesAsync();

        return Ok(new { Message = "Registration successful" });
    }
    private byte[] GenerateSalt()
    {
        var salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }

    private byte[] HashPassword(string password, byte[] salt)
    {
        using var deriveBytes = new Rfc2898DeriveBytes(password, salt, 10000);
        return deriveBytes.GetBytes(32);
    }
}
