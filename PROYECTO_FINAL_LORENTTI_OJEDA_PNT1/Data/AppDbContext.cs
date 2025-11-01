using Microsoft.EntityFrameworkCore;
using PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Models;

namespace PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
        public DbSet<CarritoItem> CarritoItems { get; set; }


        public DbSet<Compra> Compra { get; set; }
        public DbSet<CompraItem> CompraItem { get; set; }
    }
}