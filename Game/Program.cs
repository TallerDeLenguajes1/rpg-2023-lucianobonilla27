// See https://aka.ms/new-console-template for more information
using EspacioPersonaje;


Personaje nuevo;
FabricaDePersonaje fp = new();
List<Personaje> ListaPersonajes = new();
PersonajeJson Json = new();
if (Json.Existe("Personajes.Json"))
{
    ListaPersonajes = Json.LeerPersonajes("Personajes.json");

}else
{
    for (int i = 0; i < 10; i++)
    {
    nuevo = fp.CrearPersonaje();
    ListaPersonajes.Add(nuevo);
    }
    Json.GuardarPersonajes(ListaPersonajes,"Personajes.Json");
}

mostrar(ListaPersonajes);




static void mostrar(List<Personaje> lista){
   foreach (var item in lista)
   {
        Console.WriteLine("/////////////////////");
        Console.WriteLine("Tipo: " + item.Tipo);
        Console.WriteLine("Nombre: " + item.Nombre);
        Console.WriteLine("Apodo: " + item.Apodo);
        Console.WriteLine("Edad: " + item.Edad);
        Console.WriteLine("Velocidad: " + item.Velocidad);
        Console.WriteLine("/////////////////////");
        Console.WriteLine("");

   }
}
