using TallerMecanico.Api;
using TallerMecanico.Api.Dominio;

/*
try
{
    // Usando el constructor con parámetros
    Persona persona1 = new Persona(1, "Carlos", "García", "987654321");
    persona1.MostrarNombreCompleto();
    Console.WriteLine("Teléfono : " + persona1.Telefono);

    Console.WriteLine("-----------------------------------");

    // Probando la validación del setter (esto lanzará una excepción si se deja vacío)
    Persona persona2 = new Persona();
    // persona2.Nombre = ""; // Descomenta esta línea si quieres probar que salte la excepción de validación
}
catch (Exception ex)
{
    Console.WriteLine("Error: "+ ex.Message);
}*/


var controller = new PersonaConsolaController();

//GET
// 1. Ver los registros actuales
controller.GetPersona();


//-------------------------------------------------------------------


//POST
// 2. Pedir datos por consola interactivamente
Console.WriteLine("\n--- REGISTRAR NUEVA PERSONA ---");

Console.Write("Ingrese el nombre: ");
string nombre = Console.ReadLine();

Console.Write("Ingrese el apellido: ");
string apellido = Console.ReadLine();

Console.Write("Ingrese el teléfono: ");
string telefono = Console.ReadLine();

// 3. Enviar los datos capturados al controlador
controller.PostPersona(nombre, apellido, telefono);

// 4. Volver a listar para confirmar
controller.GetPersona();

 
//-------------------------------------------------------------------


//PUT
// 1. Ver los registros actuales
controller.GetPersona();

// 2. Pedir datos por consola interactivamente
Console.WriteLine("\n--- ACTUALIZAR PERSONA ---");

Console.Write("Ingrese el ID de la persona a actualizar: ");
int id = int.Parse(Console.ReadLine());

Console.Write("Ingrese el nuevo nombre: ");
string nombre = Console.ReadLine();

Console.Write("Ingrese el nuevo apellido: ");
string apellido = Console.ReadLine();

Console.Write("Ingrese el nuevo teléfono: ");
string telefono = Console.ReadLine();

// 3. Enviar los datos actualizados al metodo PutPersona
controller.PutPersona (id, nombre, apellido,telefono);

// 4. Volver a listar para confirmar el cambio
controller.GetPersona();


//-------------------------------------------------------------------


//DELETE
// 1. Ver los registros actuales 
controller.GetPersona();

// 2. Pedir datos por consola interactivamente
Console.WriteLine("\n--- ELIMINAR PERSONA ---");
Console.Write("Ingrese el ID de la persona a eliminar: ");
int id = int.Parse(Console.ReadLine());

controller.DeletePersona(id);
controller.GetPersona();
