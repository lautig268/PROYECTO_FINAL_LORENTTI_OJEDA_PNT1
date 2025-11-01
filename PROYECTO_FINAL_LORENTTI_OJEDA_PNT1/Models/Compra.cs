namespace PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public ICollection<CompraItem> Items { get; set; }


        public Compra() { }

        // Constructor con usuario
        public Compra(int usuarioId)
        {
            UsuarioId = usuarioId;
        }

        // Constructor con usuario y lista de ítems
        public Compra(int usuarioId, ICollection<CompraItem> items)
        {
            UsuarioId = usuarioId;
            Items = items ?? new List<CompraItem>();
        }


    }
}
