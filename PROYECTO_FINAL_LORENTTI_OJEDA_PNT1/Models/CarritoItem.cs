namespace PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Models
{
    public class CarritoItem
    {
        public int Id { get; set; }

        public int CarritoId { get; set; }
        public Carrito Carrito { get; set; }

        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
        public decimal Precio { get; set; } // Guarda el precio del producto al momento de agregarlo

        // Constructor vacío
        public CarritoItem() { }

        // Constructor completo
        public CarritoItem(int carritoId, int productoId, int cantidad, decimal precio)
        {
            CarritoId = carritoId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Precio = precio;
        }

    }
    }