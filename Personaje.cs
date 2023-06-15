namespace EspacioPersonaje;
using System;
class Personaje
{

    public string Tipo { get => tipo; set => tipo = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apodo { get => apodo; set => apodo = value; }
    public DateTime FechaNac { get => fechaNac; set => fechaNac = value; }
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