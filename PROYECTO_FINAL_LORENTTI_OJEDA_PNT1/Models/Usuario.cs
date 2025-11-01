namespace PROYECTO_FINAL_LORENTTI_OJEDA_PNT1.Models
{
    public class Usuario
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Contrasena { get; set; }

        public string Telefono { get; set; }

        public Usuario() { }

        public Usuario(string email, string contrasena, string nombre, string telefono)
        {
            Email = email;
            Contrasena = contrasena;
            Telefono = telefono;
            Nombre = nombre;
        }



    }
}
