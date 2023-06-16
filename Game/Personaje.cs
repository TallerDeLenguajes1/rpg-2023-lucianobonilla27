namespace EspacioPersonaje;
using System;
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
    
    public Personaje CrearPersonaje(){
        string[] tipo = { "Guerrero",
        "Mago",
        "Arquero",
        "Ladrón",
        "Caballero"};
         string[] nombre = { "Richard",
        "Peter",
        "Robert",
        "Gabriel",
        "Federico"};
        var pj = new Personaje();
        Random rand = new();
        pj.Tipo = tipo[rand.Next(5)];
        pj.Nombre = nombre[rand.Next(5)];
        switch (pj.Tipo)
        {
            case "Guerrero":
            pj.Apodo = "invensible";
            break;
           
            case "Mago":
            pj.Apodo = "encantador";
            break;

            case "Arquero":
            pj.Apodo = "ojo de halcón";
            break;

            case "Ladrón":
            pj.Apodo = "veloz";
            break;

            case "Caballero":
            pj.Apodo = "elegante";
            break;
        }

        // Generar una fecha aleatoria entre el año 900 y el año 1500
        int year = rand.Next(1723,2024);

        // Generar un mes aleatorio entre 1 y 12
        int month = rand.Next(1, 13);

        // Generar un día aleatorio entre 1 y el último día del mes y año seleccionados
        int day = rand.Next(1, DateTime.DaysInMonth(year, month) + 1);

        // Crear la fecha de nacimiento
        pj.FechaNac  = new DateTime(year, month, day);
        pj.Edad = 2023 - year;
        pj.Velocidad = rand.Next(1,11);
        pj.Destreza = rand.Next(1,6);
        pj.Fuerza = rand.Next(1,11);
        pj.Nivel = rand.Next(1,11);
        pj.Armadura = rand.Next(1,11);
        pj.Salud = 100;

        
        
        
        
        return pj;
    }
}

class PersonajeJson
{
    public void CargarPersonaje(List<Personaje> lista){
        
    }
}