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
        Console.WriteLine("Destreza: " + item.Destreza);
        Console.WriteLine("Fuerza: " + item.Fuerza);
        Console.WriteLine("Nivel: " + item.Nivel);
        Console.WriteLine("Armadura: " + item.Velocidad);
        Console.WriteLine("/////////////////////");
        Console.WriteLine("");

   }
}

Console.WriteLine("---------ELIGIENDO OPONENTES-----------");
Random rand = new Random();
int indiceAleatorio = rand.Next(ListaPersonajes.Count);

Personaje Player1 = ListaPersonajes[indiceAleatorio];
indiceAleatorio = rand.Next(ListaPersonajes.Count);
Personaje Player2 = ListaPersonajes[indiceAleatorio];
Console.WriteLine("////////////////PLAYER 1///////////////////");
Console.WriteLine("Tipo: " + Player1.Tipo);
Console.WriteLine("Nombre: " + Player1.Nombre);
Console.WriteLine("Apodo: " + Player1.Apodo);
Console.WriteLine("Edad: " + Player1.Edad);
Console.WriteLine("Velocidad: " + Player1.Velocidad);
Console.WriteLine("Destreza: " + Player1.Destreza);
Console.WriteLine("Fuerza: " + Player1.Fuerza);
Console.WriteLine("Nivel: " + Player1.Nivel);
Console.WriteLine("Armadura: " + Player1.Velocidad);
Console.WriteLine("//////////////////////////////////////////");
Console.WriteLine("----------------VS----------------");
Console.WriteLine("////////////////PLAYER 2///////////////////");
Console.WriteLine("Tipo: " + Player2.Tipo);
Console.WriteLine("Nombre: " + Player2.Nombre);
Console.WriteLine("Apodo: " + Player2.Apodo);
Console.WriteLine("Edad: " + Player2.Edad);
Console.WriteLine("Velocidad: " + Player2.Velocidad);
Console.WriteLine("Destreza: " + Player2.Destreza);
Console.WriteLine("Fuerza: " + Player2.Fuerza);
Console.WriteLine("Nivel: " + Player2.Nivel);
Console.WriteLine("Armadura: " + Player2.Velocidad);
Console.WriteLine("//////////////////////////////////////////");
Console.WriteLine("");

int turnos = 1;
int ataque;
int efectividad;
int defensa;
int ajuste = 500;
while (Player1.Salud != 0 && Player2.Salud != 0)
{
    if ((turnos % 2) != 0) //ataca player 1 y defiende player 2
    {
        ataque = Player1.Destreza * Player1.Fuerza * Player1.Nivel;
        efectividad = rand.Next(1,101);
        defensa = Player2.Armadura * Player2.Velocidad;
        int daño = ((ataque * efectividad) - defensa)/ ajuste;
        Console.WriteLine("player 1 hizo" + daño);
        Player2.Salud -= daño;
    }else //ataca player 2 y defiende player 1
    {
        ataque = Player2.Destreza * Player2.Fuerza * Player2.Nivel;
        efectividad = rand.Next(1,101);
        defensa = Player1.Armadura * Player1.Velocidad;
        int daño = ((ataque * efectividad) - defensa)/ ajuste;
        Console.WriteLine("player 2 hizo" + daño);

        Player1.Salud -= daño;
    }
    turnos++;
}

if (Player1.Salud != 0)
{
    Console.WriteLine("ganador player1");
}else
{
    Console.WriteLine("ganador player2");
    
}