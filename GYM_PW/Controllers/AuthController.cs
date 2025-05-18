using Microsoft.AspNetCore.Mvc;
using GYM_PW.Models.User;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

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
    public async Task<IActionResult> Register(User user)
    {
        if (!ModelState.IsValid) return View(user);

        if (_context.Users.Any(u => u.Email == user.Email))
        {
            ModelState.AddModelError("Email", "El correo ya está registrado");
            return View(user);
        }

        user.Password = HashPassword(user.Password);
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            ModelState.AddModelError(string.Empty, "Email y contraseña son requeridos");
            return View();
        }

        var hashedPassword = HashPassword(password);
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email && u.Password == hashedPassword);

        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Credenciales inválidas");
            return View();
        }

        HttpContext.Session.SetString("UserEmail", user.Email);
        TempData["UserFullName"] = user.Fullname;

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Fullname),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var identity = new ClaimsIdentity(claims, "Cookies");
        await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(identity));

        return RedirectToAction("Index", "Home");
    }


    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync("Cookies");
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