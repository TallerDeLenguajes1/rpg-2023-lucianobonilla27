// See https://aka.ms/new-console-template for more information
using EspacioPersonaje;



Personaje nuevo;
FabricaDePersonaje fp = new();
List<Personaje> ListaPersonajes = new();
PersonajeJson Json = new();
string title =
@"██████╗░██████╗░░██████╗░  ░█████╗░██████╗░███████╗███╗░░██╗░█████╗░  ██████╗░███████╗
██╔══██╗██╔══██╗██╔════╝░  ██╔══██╗██╔══██╗██╔════╝████╗░██║██╔══██╗  ██╔══██╗██╔════╝
██████╔╝██████╔╝██║░░██╗░  ███████║██████╔╝█████╗░░██╔██╗██║███████║  ██║░░██║█████╗░░
██╔══██╗██╔═══╝░██║░░╚██╗  ██╔══██║██╔══██╗██╔══╝░░██║╚████║██╔══██║  ██║░░██║██╔══╝░░
██║░░██║██║░░░░░╚██████╔╝  ██║░░██║██║░░██║███████╗██║░╚███║██║░░██║  ██████╔╝███████╗
╚═╝░░╚═╝╚═╝░░░░░░╚═════╝░  ╚═╝░░╚═╝╚═╝░░╚═╝╚══════╝╚═╝░░╚══╝╚═╝░░╚═╝  ╚═════╝░╚══════╝

██████╗░░█████╗░████████╗░█████╗░██╗░░░░░██╗░░░░░░█████╗░
██╔══██╗██╔══██╗╚══██╔══╝██╔══██╗██║░░░░░██║░░░░░██╔══██╗
██████╦╝███████║░░░██║░░░███████║██║░░░░░██║░░░░░███████║
██╔══██╗██╔══██║░░░██║░░░██╔══██║██║░░░░░██║░░░░░██╔══██║
██████╦╝██║░░██║░░░██║░░░██║░░██║███████╗███████╗██║░░██║
╚═════╝░╚═╝░░╚═╝░░░╚═╝░░░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚═╝";

        Console.WriteLine(title);
        
// Pausa de 1 segundo para mostrar la portada
Thread.Sleep(1000);

Console.WriteLine("Bienvenido a la RPG Arena de Batalla");
Console.Write("Cargando.");
for (int i = 0; i < 3; i++)
{
    Thread.Sleep(500);
    Console.Write(".");
}
Console.WriteLine("");


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

Console.WriteLine("╔══════════════════════════════════╗");
Console.WriteLine("║           MENÚ DE JUEGO          ║");
Console.WriteLine("╠══════════════════════════════════╣");
Console.WriteLine("║ 1. Iniciar enfrentamiento        ║");
Console.WriteLine("║                                  ║");
Console.WriteLine("║ 2. Cargar personaje              ║");
Console.WriteLine("║                                  ║");
Console.WriteLine("║ 3. Elegir personaje              ║");
Console.WriteLine("╚══════════════════════════════════╝");

int menu = Convert.ToInt32(Console.ReadLine());
switch (menu)
{
    case 1:
    break;
    case 2:
    Console.WriteLine("Nombre:");
    nuevo = new();
    nuevo.Nombre = Console.ReadLine();
    Console.WriteLine("Apodo:");
    nuevo.Apodo = Console.ReadLine();
    Console.WriteLine("Tipo:");
    nuevo.Tipo = Console.ReadLine();
    nuevo.FechaNac = DateTime.Now;
    Console.WriteLine("Edad:");
    nuevo.Edad = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Velocidad:");
    nuevo.Velocidad = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Destreza:");
    nuevo.Destreza = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Fuerza:");
    nuevo.Fuerza = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Nivel:");
    nuevo.Nivel = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Armadura:");
    nuevo.Armadura = Convert.ToInt32(Console.ReadLine());
    nuevo.Salud = 100;
    ListaPersonajes.Add(nuevo);
    Json.GuardarPersonajes(ListaPersonajes,"Personajes.Json");

    Console.WriteLine("Su personaje fue cargado con exito!");
    Environment.Exit(0);

    break;
    case 3:
    break;
    default:
    Console.WriteLine("Numero invalido");
    Environment.Exit(0);
    break;
}

Console.WriteLine("Estos son nuestros Peleadores disponibles:");
Thread.Sleep(1000);
mostrarLista(ListaPersonajes);




static void mostrarLista(List<Personaje> lista){
   foreach (var item in lista)
   {
Console.WriteLine("╔══════════════════════════════════════╗");
Console.WriteLine("║ Tipo: " + item.Tipo.PadRight(30) + " ║");
Console.WriteLine("║ Nombre: " + item.Nombre.PadRight(28) + " ║");
Console.WriteLine("║ Apodo: " + item.Apodo.PadRight(29) + " ║");
Console.WriteLine("║ Edad: " + item.Edad.ToString().PadRight(30) + " ║");
Console.WriteLine("║ Velocidad: " + item.Velocidad.ToString().PadRight(25) + " ║");
Console.WriteLine("║ Destreza: " + item.Destreza.ToString().PadRight(26) + " ║");
Console.WriteLine("║ Fuerza: " + item.Fuerza.ToString().PadRight(28) + " ║");
Console.WriteLine("║ Nivel: " + item.Nivel.ToString().PadRight(28) + "  ║");
Console.WriteLine("║ Armadura: " + item.Armadura.ToString().PadRight(25) + "  ║");
Console.WriteLine("╚══════════════════════════════════════╝");

        Console.WriteLine("");
        Thread.Sleep(1000);


   }
}

Random rand = new Random();
int indiceAleatorio;
Personaje Player1 = new();
if (menu == 3)
{
    Console.WriteLine("Ingrese el nombre del personaje:");
      string nombreBuscado = Console.ReadLine();

        // Buscar el personaje por su nombre en la lista
        Personaje personajeEncontrado = ListaPersonajes.Find(p => p.Nombre.ToLower() == nombreBuscado.ToLower());

        // Verificar si se encontró el personaje
        if (personajeEncontrado != null)
        {
            Console.WriteLine("=== PERSONAJE Seleccionado ===");
            Player1 = personajeEncontrado;
            ListaPersonajes.Remove(personajeEncontrado);
        }
        else
        {
            Console.WriteLine("El personaje no fue encontrado");
            Environment.Exit(0);

        }

}else
{
    
    indiceAleatorio = rand.Next(ListaPersonajes.Count);
    Player1 = ListaPersonajes[indiceAleatorio];
    ListaPersonajes.Remove(ListaPersonajes[indiceAleatorio]);  //Lo quito de la lista y solo volverá el ganador
}

Console.WriteLine("╔══════════════════════════════════════╗");
Console.WriteLine("║                                      ║");
Console.WriteLine("║  EL ENFRENTAMIENTO DE HOY SERÁ       ║");
Console.WriteLine("║                                      ║");
Console.WriteLine("╚══════════════════════════════════════╝");
Thread.Sleep(1000);





indiceAleatorio = rand.Next(ListaPersonajes.Count);
Personaje Player2 = ListaPersonajes[indiceAleatorio];
ListaPersonajes.Remove(ListaPersonajes[indiceAleatorio]);

mostrarPersonaje(Player1,1);
Thread.Sleep(1000);

Console.WriteLine("----------------VS----------------");
Thread.Sleep(1000);

Console.WriteLine("");
mostrarPersonaje(Player2,2);
Thread.Sleep(1000);


Console.WriteLine("--------Se tira una moneda en la arena--------");
Console.WriteLine($"-------Si sale cara empieza atacando {Player1.Nombre}-------");
Console.WriteLine($"-------Si sale cruz empieza atacando {Player2.Nombre}-------");
Console.WriteLine("");
Thread.Sleep(1000);


string result = await FlipCoin();
Console.WriteLine($"Resultado del lanzamiento de moneda: {result}");
Console.WriteLine("");

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
        switch (rand.Next(0,3))
        {
            case 0:
             Console.WriteLine($"{Player1.Nombre} ataca y realiza " + daño + " de daño");
            break;

            case 1:
             Console.WriteLine($"El {Player1.Tipo} {Player1.Nombre} realizo un ataque causando {daño} de daño");
            
            break;

            case 2:
             Console.WriteLine($"El {Player1.Apodo} {Player1.Nombre} realizo un ataque causando {daño} de daño");
             
            break;
            
        }
        
        Player2.Salud -= daño;
    }else 
    {
        ataque = Player2.Destreza * Player2.Fuerza * Player2.Nivel;
        efectividad = rand.Next(1,101);
        defensa = Player1.Armadura * Player1.Velocidad;
        int daño = ((ataque * efectividad) - defensa)/ ajuste;
         switch (rand.Next(0,3))
        {
            case 0:
             Console.WriteLine($"{Player2.Nombre} ataca y realiza " + daño + " de daño");
            break;

            case 1:
             Console.WriteLine($"El {Player2.Tipo} {Player2.Nombre} realizo un ataque causando {daño} de daño");
            
            break;

            case 2:
             Console.WriteLine($"El {Player2.Apodo} {Player2.Nombre} realizo un ataque causando {daño} de daño");
             
            break;
            
        }
    
        Player1.Salud -= daño;
    }
    turnos++;
    Thread.Sleep(500);
    
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
Console.WriteLine("╔══════════════════════════════════════╗");
Console.WriteLine("║                                      ║");
Console.WriteLine("║            FIN DEL JUEGO             ║");
Console.WriteLine("║                                      ║");
Console.WriteLine("╚══════════════════════════════════════╝");

static void mostrarPersonaje(Personaje player,int num){
Console.WriteLine("╔══════════════════════════════════════╗");
Console.WriteLine($"║ PELEADOR {num}".PadRight(37) + "  ║");
Console.WriteLine("║ Tipo: " + player.Tipo.PadRight(30) + " ║");
Console.WriteLine("║ Nombre: " + player.Nombre.PadRight(28) + " ║");
Console.WriteLine("║ Apodo: " + player.Apodo.PadRight(29) + " ║");
Console.WriteLine("║ Edad: " + player.Edad.ToString().PadRight(30) + " ║");
Console.WriteLine("║ Velocidad: " + player.Velocidad.ToString().PadRight(25) + " ║");
Console.WriteLine("║ Destreza: " + player.Destreza.ToString().PadRight(26) + " ║");
Console.WriteLine("║ Fuerza: " + player.Fuerza.ToString().PadRight(28) + " ║");
Console.WriteLine("║ Nivel: " + player.Nivel.ToString().PadRight(28) + "  ║");
Console.WriteLine("║ Armadura: " + player.Armadura.ToString().PadRight(25) + "  ║");
Console.WriteLine("╚══════════════════════════════════════╝");

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