using GYM_PW.Interfaces;
using GYM_PW.InterfazServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GYM_PW.Models.Ser_viceGym;
using GYM_PW.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configuración del servicio de email
builder.Services.AddTransient<IEmailService, EmailService>();

//Configuracion para servicio de geography
builder.Services.AddHttpClient<IGeographyService>();

// Configuración de DbContext para PostgreSQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddHttpClient<IMachineApiService, MachineApiService>();

// Configuración de servicios para las maquinas
builder.Services.AddHttpClient<IMachineApiService>();

// Configuración de sesión
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiración de sesión
    options.Cookie.HttpOnly = true; // La cookie solo es accesible por el servidor
    options.Cookie.IsEssential = true; // Marcar como cookie esencial para GDPR
    options.Cookie.SameSite = SameSiteMode.Strict; // Protección contra CSRF
});

// Configuración de autenticación (básica para empezar)
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
}).AddCookie("Cookies", options =>
{
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied";
});

// Configuración de autorización
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// IMPORTANTE: El orden de estos middlewares es crucial
app.UseAuthentication(); // Primero autenticación
app.UseAuthorization();  // Luego autorización
app.UseSession();       // Finalmente sesión

// Configuración de rutas
app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();