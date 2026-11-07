using System.Collections.Generic;
using System.Linq;
using TallerMecanico.Api.Dominio;

namespace TallerMecanico.Api.Data
{
    public class PersonaRepository
    {
        //variable solo lectura llamada _context cuyo tipo de dato es AppDbContext.
        private readonly AppDbContext _context;

        public PersonaRepository(AppDbContext context)
        {
            _context = context;
        }
        //IMPLEMENTACIOND EL CRUD DE LA CLASE PERSONA
        public List<Persona> ObtenerTodas()
        {
            return _context.Personas.ToList();
        }

        public Persona ObtenerPorId(int id)
        {
            return _context.Personas.Find(id);
        }

        public void Agregar(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        public void Actualizar(Persona persona)
        {
            _context.Personas.Update(persona);
            _context.SaveChanges();
        }

        public void Eliminar(Persona persona)
        {
            _context.Personas.Remove(persona);
            _context.SaveChanges();
        }
    }
}
