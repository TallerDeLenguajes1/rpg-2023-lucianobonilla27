// See https://aka.ms/new-console-template for more information
using EspacioPersonaje;



Personaje nuevo;
FabricaDePersonaje fp = new();
List<Personaje> ListaPersonajes = new();
PersonajeJson Json = new();
if (Json.Existe("Personajes.Json"))
{
    ListaPersonajes = Json.LeerPersonajes("Personajes.json");
    if (ListaPersonajes.Count <= 1)
    {
        ListaPersonajes.Clear(); // Limpiar la lista existente si tiene menos de dos personajes
        for (int i = 0; i < 10; i++)
        {
        nuevo =await fp.CrearPersonajeAsync();
        ListaPersonajes.Add(nuevo);
        }
        Json.GuardarPersonajes(ListaPersonajes,"Personajes.Json");
    }
}
else
{
    for (int i = 0; i < 10; i++)
    {
    nuevo =await fp.CrearPersonajeAsync();
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


Console.WriteLine("---------ELIGIENDO OPONENTES-----------");
Random rand = new Random();
int indiceAleatorio = rand.Next(ListaPersonajes.Count);
Personaje Player1 = ListaPersonajes[indiceAleatorio];
ListaPersonajes.Remove(ListaPersonajes[indiceAleatorio]);  //Lo quito de la lista y solo volverá el ganador

indiceAleatorio = rand.Next(ListaPersonajes.Count);
Personaje Player2 = ListaPersonajes[indiceAleatorio];
ListaPersonajes.Remove(ListaPersonajes[indiceAleatorio]);

mostrarPersonaje(Player1,1);
Console.WriteLine("----------------VS----------------");
Console.WriteLine("");
mostrarPersonaje(Player2,2);

Console.WriteLine("--------Se tira una moneda en la arena--------");
Console.WriteLine("-------Si sale cara empieza atacando el Player  1-------");
Console.WriteLine("-------Si sale cruz empieza atacando el Player  2-------");
string result = await FlipCoin();
Console.WriteLine($"Resultado del lanzamiento de moneda: {result}");
int turnos;

if (result == "Cara")
{
    turnos = 1;
}else
{
    turnos = 2;
}


int ataque;
int efectividad;
int defensa;
int ajuste = 500;

Console.WriteLine("/////////////////EMPIEZA LA BATALLA//////////////////");
while (Player1.Salud > 0 && Player2.Salud > 0)
{
    if ((turnos % 2) != 0) 
    {
        ataque = Player1.Destreza * Player1.Fuerza * Player1.Nivel;
        efectividad = rand.Next(1,101);
        defensa = Player2.Armadura * Player2.Velocidad;
        int daño = ((ataque * efectividad) - defensa)/ ajuste;
        Console.WriteLine("Player 1 ataca y realiza " + daño + " de daño");
        Player2.Salud -= daño;
    }else 
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
    Player1 = incrementoNivel(Player1);
    mostrarPersonaje(Player1,1);
    ListaPersonajes.Add(Player1);
}else
{
    Console.WriteLine("//////////////EL VENCEDOR ES///////////////");
    Player2 = incrementoNivel(Player2);
    mostrarPersonaje(Player2,2);
    ListaPersonajes.Add(Player2);

    
}
Json.GuardarPersonajes(ListaPersonajes,"Personajes.Json");


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



static async Task<string> FlipCoin()
    {
        using (HttpClient client = new HttpClient())
        {
            string apiUrl = "https://www.random.org/integers/?num=1&min=0&max=1&col=1&base=10&format=plain&rnd=new";
            string response = await client.GetStringAsync(apiUrl);
            int randomNumber = int.Parse(response);
            return (randomNumber == 0) ? "Cara" : "Cruz";
        }
    }

static Personaje incrementoNivel(Personaje pj){
    pj.Armadura++;
    pj.Destreza++;
    pj.Fuerza++;
    pj.Velocidad++;
    pj.Nivel++;
    pj.Salud = 100;
    return pj;
}