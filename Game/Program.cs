// See https://aka.ms/new-console-template for more information
using EspacioPersonaje;



Personaje nuevo;
FabricaDePersonaje fp = new();
List<Personaje> ListaPersonajes = new();
PersonajeJson Json = new();
Console.WriteLine("");
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
Console.WriteLine("");


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

Console.WriteLine("");
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


Console.WriteLine("╔══════════════════════════════════════╗");
Console.WriteLine("║                                      ║");
Console.WriteLine("║        ¡EMPIEZA LA BATALLA!          ║");
Console.WriteLine("║                                      ║");
Console.WriteLine("╚══════════════════════════════════════╝");
Console.WriteLine("");

while (Player1.Salud > 0 && Player2.Salud > 0)
{
    if ((turnos % 2) != 0) 
    {
        ataque = Player1.Destreza * Player1.Fuerza * Player1.Nivel;
        efectividad = rand.Next(1,101);
        defensa = Player2.Armadura * Player2.Velocidad;
        int daño = ((ataque * efectividad) - defensa)/ ajuste;
        switch (rand.Next(0,4))
        {
            case 0:
             Console.WriteLine($"¡Un ataque devastador! {Player1.Nombre} realiza " + daño + " de daño");
            break;

            case 1:
             Console.WriteLine($"La lucha es feroz, El {Player1.Tipo} {Player1.Nombre} realizo un ataque causando {daño} de daño");
            
            break;

            case 2:
             Console.WriteLine($"El {Player1.Apodo} {Player1.Nombre} realizo un ataque causando {daño} de daño");
             
            break;

            case 3:
             Console.WriteLine($"¡Un golpe certero! {Player1.Nombre} realiza " + daño + " de daño");
            break;
            
        }
        
        Player2.Salud -= daño;
    }else 
    {
        ataque = Player2.Destreza * Player2.Fuerza * Player2.Nivel;
        efectividad = rand.Next(1,101);
        defensa = Player1.Armadura * Player1.Velocidad;
        int daño = ((ataque * efectividad) - defensa)/ ajuste;
         switch (rand.Next(0,4))
        {
            case 0:
             Console.WriteLine($"¡Que impresionante! {Player2.Nombre} ataca y realiza " + daño + " de daño");
            break;

            case 1:
             Console.WriteLine($"¡Maravillosa juagada! El {Player2.Tipo} {Player2.Nombre} causando {daño} de daño");
            
            break;

            case 2:
             Console.WriteLine($"¡Los golpes son rápidos y certeros! El {Player2.Apodo} {Player2.Nombre} realizó {daño} de daño");
             
            break;

            case 3:
             Console.WriteLine($" El enemigo se encuentra en aprietos tras el ataque de {Player2.Nombre} con " + daño + " de daño");
            
            break;
        }
    
        Player1.Salud -= daño;
    }
    turnos++;
    Thread.Sleep(500);
    
}


Console.WriteLine("");
if (Player1.Salud > 0)
{
    Console.WriteLine("╔══════════════════════════════════════╗");
    Console.WriteLine("║              VENCEDOR                ║");
    Player1 = incrementoNivel(Player1);
    mostrarPersonaje(Player1,1);
    ListaPersonajes.Add(Player1);
}else
{
    Console.WriteLine("╔══════════════════════════════════════╗");
    Console.WriteLine("║              VENCEDOR                ║");
    Player2 = incrementoNivel(Player2);
    mostrarPersonaje(Player2,2);
    ListaPersonajes.Add(Player2);

    
}
Thread.Sleep(500);


Console.WriteLine("");
Console.WriteLine("La antorcha de la gloria ahora brilla en tus manos, honra tu fuerza y destreza");
Thread.Sleep(1000);

string antorcha = @"__________________________________________________
____________________________1111__________________
___________________________11_1¶¶1________________
___________________________11_1__¶¶1______________
___________________________11_1¶1_1¶¶_____________
___________________________11_1¶¶¶1_¶¶1___________
____________________________1_1¶¶¶¶1_1¶1__________
___________________________11_1¶¶¶¶¶¶11¶¶_________
___________________________1__¶1¶¶¶¶¶¶11¶1________
___________________________1_1¶1¶¶¶¶¶1¶11¶1_______
_____________________11¶__11_¶¶1¶¶¶¶¶¶1¶1¶¶_______
____________________111¶¶¶1_1¶1¶¶¶¶¶¶¶1¶¶1¶¶______
____________________1_11_1_1¶¶1¶¶¶¶¶¶¶¶1¶1¶¶______
____________________11¶¶111¶¶11¶¶1¶¶¶¶¶1¶¶1¶1_____
____________________11¶¶11¶111¶¶¶__¶¶¶¶1¶¶1¶¶_____
___________________11¶1¶¶1111¶¶¶¶___¶¶¶¶1¶¶¶¶1____
__________________1¶¶11¶¶¶¶¶¶¶¶¶1___1¶¶¶1¶1¶¶1____
__________________¶¶¶11¶¶¶¶¶¶¶¶¶_____¶¶¶1¶¶¶¶¶____
_________________¶¶¶11¶¶¶¶¶¶11¶1_____¶¶¶1¶¶¶¶¶____
_________________¶¶¶11¶¶¶¶¶¶______1__¶¶¶1¶¶¶¶1____
________________1¶¶11¶¶¶¶¶¶______11__¶¶¶¶¶¶¶¶1____
________________1¶¶1¶¶¶¶¶¶___11111___¶¶1¶¶¶¶¶_____
_________________¶¶1¶¶¶¶¶1___1111____¶¶1¶¶¶¶______
__________________¶¶¶¶¶¶¶__111111___¶¶11¶¶¶_______
___________________¶¶¶¶¶¶_1111111__¶¶¶¶¶¶¶________
_______________1111111¶¶¶__1__111_¶¶¶¶¶1__________
_______________¶1_______11_111___1¶11¶1__11_______
________________11111¶1111111¶_11_________¶¶1_____
_________________¶1111111111¶¶_111_11_1¶1¶¶¶______
__________________¶111111111¶111111111¶¶¶¶________
__________________111¶11¶11¶¶¶¶1¶¶1¶1¶¶¶¶_________
__________________¶11111111¶¶¶11¶11¶¶¶¶¶__________
__________________1111111111¶11¶11111¶¶¶__________
___________________1¶1111111¶1¶11¶1¶¶¶1___________
___________________11111111¶111111¶¶¶¶____________
___________________11111111¶¶¶11111¶¶1____________
____________________1111111¶¶111111¶¶_____________
____________________1111111¶¶111111¶¶_____________
____________________1111111¶¶111111¶¶_____________
____________________¶111111¶111111¶¶1_____________
____________________¶11111¶¶¶11111¶¶______________
____________________¶11111¶¶¶11111¶¶______________
___________________1¶11111¶¶_11111¶¶______________
____________________¶111111¶¶1111¶¶1______________
____________________1111111¶¶1111¶¶_______________
____________________111111¶¶11111¶¶_______________
____________________¶111111¶1111¶¶1_______________
____________________111111¶¶1111¶¶1_______________
____________________111111¶¶111¶¶¶________________
____________________11111¶¶111¶¶¶1________________
____________________11111¶¶111¶¶¶_________________
____________________11111¶¶111¶¶__________________
__________________1111111¶¶11¶¶¶__________________
________________1¶¶11¶¶¶¶¶¶11¶¶¶__________________
______________1¶¶¶¶¶11111111¶¶¶¶1_________________
____________11¶111____1____¶¶¶¶¶__________________
_1111111111111_111¶¶¶¶¶¶¶¶¶¶¶¶¶¶__________________
_________111111¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶¶___________________
_11111111¶¶¶¶¶¶¶¶¶¶¶¶111¶111¶¶____________________
_¶¶¶11¶¶¶¶¶¶¶¶¶¶¶¶¶¶11111_11¶1____________________
_111¶¶¶¶¶¶¶¶11111______1¶11¶¶_____________________
_¶¶¶¶11_____________1111¶11¶¶_____________________
_____________________111¶11¶¶_____________________
_____________________1¶¶¶¶¶¶______________________
_____________________11¶1¶¶1______________________
__________________________________________________
__________________________________________________
";
Console.WriteLine(antorcha);


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