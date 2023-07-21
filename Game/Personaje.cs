namespace EspacioPersonaje;
using System;
using System.Text.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
class Personaje
{

    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
    public int Edad { get => edad; set => edad = value; }
    public int Velocidad { get => velocidad; set => velocidad = value; }
    public int Destreza { get => destreza; set => destreza = value; }
    public int Fuerza { get => fuerza; set => fuerza = value; }
    public int Nivel { get => nivel; set => nivel = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Salud { get => salud; set => salud = value; }

    ///////DATOS/////
    string tipo;
    string nombre;
    string apodo;
    DateTime fechaNac;
    int edad;//0 a 300
    
    ////////////////
    
    //CARACTERISTICAS///

    int velocidad; //1 al 10
    int destreza; //1 al 5
    int fuerza;//1 al 10
    int nivel;//1 al 10
    int armadura;//1 al 10
    int salud;//100
    
    //////////////////////
    
    
}

class FabricaDePersonaje
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public async Task<Personaje> CrearPersonajeAsync()
    {
        string[] tipo = { "Guerrero", "Mago", "Arquero", "Ladrón", "Caballero" };

        // Obtener nombres aleatorios de hombres de la API
        string[] nombres = await ObtenerNombresAleatoriosAsync(5, gender: "male");

        var pj = new Personaje();
        Random rand = new();
        pj.Tipo = tipo[rand.Next(5)];
        pj.Nombre = nombres[rand.Next(5)];
        switch (pj.Tipo)
        {
            case "Guerrero":
                pj.Apodo = "invensible";
                pj.Velocidad = 4;
                pj.Destreza = 3;
                pj.Fuerza = 5;
                pj.Armadura = 3;
                break;

            case "Mago":
                pj.Apodo = "encantador";
                pj.Velocidad = 4;
                pj.Destreza = 2;
                pj.Fuerza = 6;
                pj.Armadura = 5;
                break;

            case "Arquero":
                pj.Apodo = "ojo de halcón";
                pj.Velocidad = 4;
                pj.Destreza = 4;
                pj.Fuerza = 4;
                pj.Armadura = 3;
                break;

            case "Ladrón":
                pj.Apodo = "veloz";
                pj.Velocidad = 6;
                pj.Destreza = 4;
                pj.Fuerza = 3;
                pj.Armadura = 2;
                break;

            case "Caballero":
                pj.Apodo = "elegante";
                pj.Velocidad = 2;
                pj.Destreza = 4;
                pj.Fuerza = 4;
                pj.Armadura = 5;
                break;
        }

        // Generar una fecha aleatoria entre el año 900 y el año 1500
        int year = rand.Next(1723, 2024);

        // Generar un mes aleatorio entre 1 y 12
        int month = rand.Next(1, 13);

        // Generar un día aleatorio entre 1 y el último día del mes y año seleccionados
        int day = rand.Next(1, DateTime.DaysInMonth(year, month) + 1);

        // Crear la fecha de nacimiento
        pj.FechaNac = new DateTime(year, month, day);
        pj.Edad = 2023 - year;
        pj.Nivel = 3; //El nivel subira cuando un personaje gane alguna batalla, subiendo ademas todas sus stats
        pj.Salud = 100;

        return pj;
    }

    private async Task<string[]> ObtenerNombresAleatoriosAsync(int cantidad, string gender)
    {
        string apiUrl = $"https://randomuser.me/api/?results={cantidad}&gender={gender}";

        using (HttpResponseMessage response = await _httpClient.GetAsync(apiUrl))
        {
            string responseBody = await response.Content.ReadAsStringAsync();

            // Procesar la respuesta JSON y obtener los nombres
            JsonDocument jsonDocument = JsonDocument.Parse(responseBody);
            JsonElement root = jsonDocument.RootElement;

            string[] nombres = new string[cantidad];
            int index = 0;

            foreach (JsonElement user in root.GetProperty("results").EnumerateArray())
            {
                string firstName = user.GetProperty("name").GetProperty("first").GetString();
                string lastName = user.GetProperty("name").GetProperty("last").GetString();

                nombres[index] = $"{firstName} {lastName}";
                index++;
            }

            return nombres;
        }
    }
}

class PersonajeJson
{
    public void GuardarPersonajes(List<Personaje> lista, string archivo)
        {
            string jsonString = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(archivo, jsonString);
        }

     public List<Personaje> LeerPersonajes(string archivo)
    {
        string jsonString = File.ReadAllText(archivo);
        List<Personaje> lista = JsonSerializer.Deserialize<List<Personaje>>(jsonString);
        return lista;
    }     

    public bool Existe(string archivo){
        if (File.Exists(archivo))
        {
            string jsonString = File.ReadAllText(archivo);
            return !string.IsNullOrEmpty(jsonString);
        }
        return false;
    }
}

// API NOMBRES

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Coordinates
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class Dob
    {
        public DateTime date { get; set; }
        public int age { get; set; }
    }

    public class Id
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Info
    {
        public string seed { get; set; }
        public int results { get; set; }
        public int page { get; set; }
        public string version { get; set; }
    }

    public class Location
    {
        public Street street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public object postcode { get; set; }
        public Coordinates coordinates { get; set; }
        public Timezone timezone { get; set; }
    }

    public class Login
    {
        public string uuid { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string md5 { get; set; }
        public string sha1 { get; set; }
        public string sha256 { get; set; }
    }

    public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }

    public class Picture
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }
    }

    public class Registered
    {
        public DateTime date { get; set; }
        public int age { get; set; }
    }

    public class Result
    {
        public string gender { get; set; }
        public Name name { get; set; }
        public Location location { get; set; }
        public string email { get; set; }
        public Login login { get; set; }
        public Dob dob { get; set; }
        public Registered registered { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
        public Id id { get; set; }
        public Picture picture { get; set; }
        public string nat { get; set; }
    }

    public class Root
    {
        public List<Result> results { get; set; }
        public Info info { get; set; }
    }

    public class Street
    {
        public int number { get; set; }
        public string name { get; set; }
    }

    public class Timezone
    {
        public string offset { get; set; }
        public string description { get; set; }
    }

