using Microsoft.AspNetCore.Mvc;
using GYM_PW.Models.User;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

public class AuthController : Controller
{
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Register(User user) // Cambia a async Task
    {
        if (!ModelState.IsValid) return View(user);

        if (_context.Users.Any(u => u.Email == user.Email))
        {
            ModelState.AddModelError("Email", "El correo ya está registrado");
            return View(user);
        }

        user.Password = HashPassword(user.Password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync(); // Añade await

        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var hashedPassword = HashPassword(password);
        var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == hashedPassword);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Credenciales inválidas");
            return View();
        }

        // Aquí podrías usar Session, TempData o cookies para guardar el estado de login
        TempData["UserFullName"] = user.Fullname;

        return RedirectToAction("Index", "Home");
    }

    private string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}
