using PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Conexión a SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración del middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redirección HTTP -> HTTPS
app.UseStaticFiles();      // Servir archivos estáticos (CSS, JS, imágenes, etc.)

app.UseRouting();          // Habilita el enrutamiento
app.UseAuthorization();    // Middleware de autorización (si lo necesitas)

// Definir ruta por defecto (MVC)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Ejecuta la app
    