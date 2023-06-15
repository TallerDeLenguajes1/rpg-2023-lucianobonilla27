// See https://aka.ms/new-console-template for more information
using EspacioPersonaje;

Personaje nuevo;
FabricaDePersonaje fp = new();
nuevo = fp.CrearPersonaje();
Console.WriteLine(nuevo.Apodo);
