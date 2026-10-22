namespace TallerMecanico.Api.Dominio
{
    public class Persona
    {
        public  int Id { get; private set; }
        private string _nombre;
        private string _apellido;
        public string Telefono { get; set; }

        
        public Persona() { }

        public Persona(int id, string nombre, string apellido)
        {
            Id = id;
            _nombre = nombre;
            _apellido = apellido;
        }
        public string Nombre
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
        public string Apellido
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
        public string NombreCompleto
        {
            get { return Nombre + " " + Apellido; }
        }

        
    }
}
