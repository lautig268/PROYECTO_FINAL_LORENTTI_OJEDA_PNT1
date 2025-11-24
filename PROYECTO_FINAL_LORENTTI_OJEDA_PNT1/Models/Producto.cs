namespace PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Models
{
    public class Producto
    {

        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public string Imagen { get; set; }

        public ICollection<CarritoItem> CarritoItems { get; set; }

        public Producto() { }

        public Producto(string nombre, string descripcion, decimal precio, int stock, string imagen)
        {
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
            Nombre = nombre;
            Imagen = imagen;
        }
    }
}
