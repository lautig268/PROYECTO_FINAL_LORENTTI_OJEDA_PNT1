namespace PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Models
{
    public class CompraItem
    {
        public int Id { get; set; }

        public int ProductoId { get; set; }
        public Compra Compraa { get; set; }

        public int CompraId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }




        public CompraItem() { }

        public CompraItem(int id, int productoId, Compra compraa, int compraId, Producto producto, int cantidad)
        {

            Id = id;
            ProductoId = productoId;
            Compraa = compraa;
            CompraId = compraId;
            Producto = producto;
            Cantidad = cantidad;




        }



    }
}
