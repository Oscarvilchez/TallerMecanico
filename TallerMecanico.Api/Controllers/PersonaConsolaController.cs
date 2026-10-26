
using TallerMecanico.Api.Data;
using TallerMecanico.Api.Dominio;
using TallerMecanico.Api.Controllers;
using System.Security.Cryptography.X509Certificates;

namespace TallerMecanico.Api
{
    public class PersonaConsolaController
    {
        // GET: Listar registros
        public void GetPersona()
        {
            using var context = new AppDbContext();
            var personas = context.Personas.ToList();

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
            using var context = new AppDbContext();

            // Creamos la instancia y asignamos los valores (esto activará las validaciones de tu clase Persona)
            var nuevaPersona = new Persona
            {
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono
            };

            context.Personas.Add(nuevaPersona);
            context.SaveChanges();

            Console.WriteLine("Se Agrego a : " + nuevaPersona.NombreCompleto);
        }

        // PUT : Actualziar datos
        public void PutPersona(int id, string nuevoNombre, string nuevoApellido, string nuevoTelefono)
        {
            using var context = new AppDbContext();

            //Buscamos por ID el registro que queremos ACTUALIZAR
            var persona = context.Personas.Find(id);
            if (persona != null)
            {
                // 2. Actualizamos las propiedades
                persona.Nombre = nuevoNombre;
                persona.Apellido = nuevoApellido;
                persona.Telefono = nuevoTelefono;

                // 3. Guardamos los cambios
                context.SaveChanges();

                Console.WriteLine("\n[PUT EXITOSO] Se actualizó correctamente el registro con ID " + id + ".");
            }
            else
            {
                Console.WriteLine($"\n[PUT ERROR] No se encontró ninguna persona con el ID " + id + ".");
            }
        }
        public void DeletePersona(int id)
        {
            using var context = new AppDbContext();
            //Buscamos por ID el registro que queremos ELIMINAR
            var persona = context.Personas.Find(id);
            if (persona != null)
            {
                context.Personas.Remove(persona);                
                context.SaveChanges();
                Console.WriteLine("Se elimino el registro con ID " + id + ".");
            }
            else
            {
                Console.WriteLine("No se encontro registro de ID "+ id + ".");
            }    

        }
    }
}
