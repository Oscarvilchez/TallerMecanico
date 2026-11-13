using System;
namespace TallerMecanico.Api.Dominio
{
    public class Persona
    {
        // 1. CAMPOS (Variables privadas)
        private string _nombre = string.Empty;
        private string _apellido = string.Empty;

        // 2. CONSTRUCTORES
        public Persona()
        {
        }
        public Persona(int id, string nombre, string apellido)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
        }
        public Persona(int id, string nombre, string apellido, string telefono)
        : this(id, nombre, apellido) //Encadenamiento de constructores.
        {
            Telefono = telefono;
        }

        // 3. PROPIEDADES
        public int Id { get; private set; }
        public string? Telefono { get; set; }

        public required string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre no puede estar vacío o ser nulo.");
                }
                _nombre = value;
            }
        }
        public required string Apellido
        {
            get { return _apellido; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El apellido no puede estar vacío o ser nulo.");
                }
                _apellido = value;
            }
        }
        public string NombreCompleto { get { return Nombre + " " + Apellido; } }


        /*/ 4. MÉTODOS
       
        public void MostrarNombreCompleto()
        {
            Console.WriteLine("Nombre completo: "+ NombreCompleto);
        }*/
    }
}
