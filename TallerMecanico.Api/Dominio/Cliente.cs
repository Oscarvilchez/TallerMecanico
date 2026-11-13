namespace TallerMecanico.Api.Dominio
{
    
    public class Cliente : Persona
    {
        private string _dni = string.Empty;

        // 1. CONSTRUCTORES
        public Cliente()
        {
        }        
        public Cliente(int id, string nombre, string apellido, string telefono, string dni)
            : base(id, nombre, apellido, telefono)//Encadenamiento de constructores.
        {
            Dni = dni;
        }

        // 2. PROPIEDADES            
        public required string Dni
        {
            get { return _dni; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length != 8 || !value.All(char.IsDigit))
                {
                    throw new ArgumentException("El DNI es un campo obligatorio");
                }
                _dni = value;
            }
        }
    }
}
