namespace PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Models
{
    public class Carrito
    {

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<CarritoItem> Items { get; set; }


        public Carrito() { }

        // Constructor con usuario
        public Carrito(int usuarioId)
        {
            UsuarioId = usuarioId;
        }

        // Constructor con usuario y lista de ítems
        public Carrito(int usuarioId, ICollection<CarritoItem> items)
        {
            UsuarioId = usuarioId;
            Items = items ?? new List<CarritoItem>();
        }

    }
}
