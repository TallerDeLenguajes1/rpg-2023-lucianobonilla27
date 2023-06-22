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

mostrarLista(ListaPersonajes);




static void mostrarLista(List<Personaje> lista){
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

static void mostrarPersonaje(Personaje player,int num){
    Console.WriteLine("////////////////PLAYER {0}///////////////////",num);
    Console.WriteLine("Tipo: " + player.Tipo);
    Console.WriteLine("Nombre: " + player.Nombre);
    Console.WriteLine("Apodo: " + player.Apodo);
    Console.WriteLine("Edad: " + player.Edad);
    Console.WriteLine("Velocidad: " + player.Velocidad);
    Console.WriteLine("Destreza: " + player.Destreza);
    Console.WriteLine("Fuerza: " + player.Fuerza);
    Console.WriteLine("Nivel: " + player.Nivel);
    Console.WriteLine("Armadura: " + player.Velocidad);
    Console.WriteLine("//////////////////////////////////////////");
    Console.WriteLine("");
}

Console.WriteLine("---------ELIGIENDO OPONENTES-----------");
Random rand = new Random();
int indiceAleatorio = rand.Next(ListaPersonajes.Count);

Personaje Player1 = ListaPersonajes[indiceAleatorio];
indiceAleatorio = rand.Next(ListaPersonajes.Count);
Personaje Player2 = ListaPersonajes[indiceAleatorio];
mostrarPersonaje(Player1,1);
Console.WriteLine("----------------VS----------------");
mostrarPersonaje(Player2,2);

int turnos = 1;
int ataque;
int efectividad;
int defensa;
int ajuste = 500;
while (Player1.Salud > 0 && Player2.Salud > 0)
{
    if ((turnos % 2) != 0) //ataca player 1 y defiende player 2
    {
        ataque = Player1.Destreza * Player1.Fuerza * Player1.Nivel;
        efectividad = rand.Next(1,101);
        defensa = Player2.Armadura * Player2.Velocidad;
        int daño = ((ataque * efectividad) - defensa)/ ajuste;
        Console.WriteLine("Player 1 ataca y realiza " + daño + " de daño");
        Player2.Salud -= daño;
    }else //ataca player 2 y defiende player 1
    {
        ataque = Player2.Destreza * Player2.Fuerza * Player2.Nivel;
        efectividad = rand.Next(1,101);
        defensa = Player1.Armadura * Player1.Velocidad;
        int daño = ((ataque * efectividad) - defensa)/ ajuste;
        Console.WriteLine("Player 2 ataca y realiza " + daño + " de daño");
        Player1.Salud -= daño;
    }
    turnos++;
}

if (Player1.Salud > 0)
{
    Console.WriteLine("//////////////EL VENCEDOR ES///////////////");
    Player1.Salud = 100;
    Player1.Nivel+= 5;
    mostrarPersonaje(Player1,1);
    ListaPersonajes.Remove(Player2);
}else
{
    Console.WriteLine("//////////////EL VENCEDOR ES///////////////");
    Player2.Salud = 100;
    Player2.Nivel+= 5;
    mostrarPersonaje(Player2,1);
    ListaPersonajes.Remove(Player1);

    
}