using TallerMecanico.Api.Data;
using TallerMecanico.Api.Dominio;

namespace TallerMecanico.Api.Data
{
    public class PersonaRepository
    {
        public List<Persona> ObtenerTodas()
        {
            using var context = new AppDbContext();
            return context.Personas.ToList();
        }

        public Persona ObtenerPorId(int id)
        {
            using var context = new AppDbContext();
            return context.Personas.Find(id);
        }

        public void Agregar(Persona persona)
        {
            using var context = new AppDbContext();
            context.Personas.Add(persona);
            context.SaveChanges();
        }

        public void Actualizar(Persona persona)
        {
            using var context = new AppDbContext();
            context.Personas.Update(persona);
            context.SaveChanges();
        }

        public void Eliminar(Persona persona)
        {
            using var context = new AppDbContext();
            context.Personas.Remove(persona);
            context.SaveChanges();
        }
    }
}