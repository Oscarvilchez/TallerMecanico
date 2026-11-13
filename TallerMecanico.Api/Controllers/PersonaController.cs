using Microsoft.AspNetCore.Mvc;
using TallerMecanico.Api.Data;
using TallerMecanico.Api.Dominio;
using System.Collections.Generic;

namespace TallerMecanico.Api.Controllers
{
    // ETIQUETAS DE LA CLASE
    [ApiController]                    
    [Route("api/[controller]")] 
    public class PersonaController : ControllerBase 
    {
        private readonly PersonaRepository _repository;
        
        public PersonaController(PersonaRepository repository)
        {
            _repository = repository;
        }
                 
        // ENDPOINT 1: GET (Listar registros)
         
        [HttpGet] // Etiqueta: Responde a peticiones GET de HTTP
        public ActionResult<IEnumerable<Persona>> GetPersona()
        {
            var personas = _repository.ObtenerTodas();
            return Ok(personas); // Retorna un HTTP 200 con la lista en formato JSON para Swagger
        }

        // ENDPOINT 2: POST (Insertar un nuevo registro)
         
        [HttpPost] // Etiqueta: Responde a peticiones POST de HTTP
        public IActionResult PostPersona([FromBody] Persona nuevaPersona)
        {
            try
            {            
            _repository.Agregar(nuevaPersona);

            return Ok(new { mensaje = "Persona agregada con éxito", datos = nuevaPersona });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = "Error al agregar persona", error = ex.Message });
            }
        }

        
        // ENDPOINT 3: PUT (Actualizar datos)
        
        [HttpPut("{id}")] // Etiqueta: Recibe el ID por la URL (ejemplo: api/persona/5)
        public IActionResult PutPersona(int id, [FromBody] Persona personaActualizada)
        {
            var personaEnBD = _repository.ObtenerPorId(id);
            if (personaEnBD == null)
            {
                return NotFound("PUT ERROR - No se encontró ninguna persona con el ID" + id); // HTTP 404
            }

            // Actualizamos las propiedades
            personaEnBD.Nombre = personaActualizada.Nombre;
            personaEnBD.Apellido = personaActualizada.Apellido;
            personaEnBD.Telefono = personaActualizada.Telefono;

            _repository.Actualizar(personaEnBD);
            return Ok(new { mensaje = "PUT EXITOSO - Se actualizó correctamente persona con ID:" + id }); // HTTP 200
        }

        
        // ENDPOINT 4: DELETE (Eliminar datos)
        
        [HttpDelete("{id}")] // Etiqueta: Recibe el ID a eliminar por la URL
        public IActionResult DeletePersona(int id)
        {
            var personaEnBD = _repository.ObtenerPorId(id);
            if (personaEnBD == null)
            {
                return NotFound("No se encontró registro de ID: " + id); // HTTP 404
            }

            _repository.Eliminar(personaEnBD);
            return Ok(new { mensaje = "Se eliminó el registro con ID: " + id }); // HTTP 200
        }
    }
}
