using GYM_PW.Interfaces;
using GYM_PW.Models;
using GYM_PW.Views.ContactView;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GYM_PW.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public ContactController(ILogger<ContactController> logger, IEmailService emailService, IConfiguration configuration)
        {
            _logger = logger;
            _emailService = emailService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contacto()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(ContactModel contactModel)
        {
            await _emailService.EnviarCorreoContacto(contactModel);
            TempData["Mensaje"] = "¡Mensaje enviado correctamente!";
            return RedirectToAction("Contacto");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
