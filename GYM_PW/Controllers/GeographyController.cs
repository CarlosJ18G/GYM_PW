using GYM_PW.Interfaces;
using GYM_PW.Models;
using GYM_PW.Models.Geography;
using GYM_PW.Services;
using GYM_PW.Views.ContactView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.Json;
using Newtonsoft.Json.Linq;
namespace GYM_PW.Controllers
{
    public class GeographyController: Controller
    {
        private readonly ILogger<GeographyController> _logger;
        private readonly IGeographyService _geographyService;
        private readonly ApplicationDbContext _context;
        public GeographyController(ILogger<GeographyController> logger, IEmailService emailService, ApplicationDbContext context, IGeographyService _configuration)
        {
            _logger = logger;
            _context = context;
            _geographyService =_configuration;
        }

        [HttpGet]
        public async Task<IActionResult> PruebaGeoAsync()
        {
            var countries = await _geographyService.GetCountriesAsync(); //Llama al servicio para obtener los países
            //La respuesta de GetCountriesAsync es una lista
            return View(countries);
        }

        [HttpGet]
        public async Task<IActionResult> PruebaGeoEstados()
        {
            //var json = await _geographyService.GetCountriesAsync();
            //var geoData = JsonSerializer.Deserialize<GeoNamesCountryResponse>(json);
            //return View(geoData);
            var countries = await _geographyService.GetStatesByCountryAsync("CO");
            return View(countries);
        }

        //[HttpPost]
        //public async Task<IActionResult> PruebaGeo(Countries country)
        //{
        //    //if (!ModelState.IsValid) return View(country);

        //    //if (_context.Countries.Any(u => u.Name == country.Name))
        //    //{
        //    //    ModelState.AddModelError("Name", "El nombre de pais ya está registrado");
        //    //    return View(country);
        //    //}
        //    ////country.Active = true;

        //    //_context.Countries.Add(country); // <-- Agrega esta línea

        //    //await _context.SaveChangesAsync();

        //    //return RedirectToAction("PruebaGeo");

        //    var json = await _geographyService.GetCountriesAsync();

        //    // Opcional: deserializar si quieres trabajar con objetos
        //    var geoData = /*JsonSerializer.Deserialize<GeoNamesCountryResponse>*/(json);

        //    return View(geoData);
        //}

    }
}
