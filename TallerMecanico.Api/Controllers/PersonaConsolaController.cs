
using TallerMecanico.Api.Data;
using TallerMecanico.Api.Dominio;


namespace TallerMecanico.Api
{
    public class PersonaConsolaController
    {
        private readonly PersonaRepository _repository = new PersonaRepository();

        // GET: Listar registros
        public void GetPersona()
        {
            var personas = _repository.ObtenerTodas();

            Console.WriteLine("\n--- LISTA DE PERSONAS EN BD ---");
            foreach (var p in personas)
            {
                Console.WriteLine(" ID      : " + p.Id);
                Console.WriteLine(" Nombre  : " + p.NombreCompleto);
                Console.WriteLine(" Teléfono: " + p.Telefono);
                Console.WriteLine("-------------------------------------------");

            }
        }
        // POST: Insertar un nuevo registro
        public void PostPersona(string nombre, string apellido, string telefono)
        {            

            // Creamos la instancia y asignamos los valores (esto activará las validaciones de tu clase Persona)
            var nuevaPersona = new Persona
            {
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono
            };

            _repository.Agregar(nuevaPersona);           

            Console.WriteLine("Se Agrego a : " + nuevaPersona.NombreCompleto);
        }
        // PUT : Actualziar datos
        public void PutPersona(int id, string nuevoNombre, string nuevoApellido, string nuevoTelefono)
        {
            //Buscamos por ID el registro que queremos ACTUALIZAR
            var persona = _repository.ObtenerPorId(id);
            if (persona != null)
            {
                // 2. Actualizamos las propiedades
                persona.Nombre = nuevoNombre;
                persona.Apellido = nuevoApellido;
                persona.Telefono = nuevoTelefono;

                // 3. Guardamos los cambios
                _repository.Actualizar(persona);

                Console.WriteLine("\n[PUT EXITOSO] Se actualizó correctamente el registro con ID " + id + ".");
            }
            else
            {
                Console.WriteLine($"\n[PUT ERROR] No se encontró ninguna persona con el ID " + id + ".");
            }
        }
        // DELETE : Eliminar datos
        public void DeletePersona(int id)
        {
            //Buscamos por ID el registro que queremos ELIMINAR
            var persona = _repository.ObtenerPorId(id);
            if (persona != null)
            {
                _repository.Eliminar(persona);               
          
                Console.WriteLine("Se elimino el registro con ID " + id + ".");
            }
            else
            {
                Console.WriteLine("No se encontro registro de ID "+ id + ".");
            }    

        }
    }
}
