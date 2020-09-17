using System;
using System.Collections.Generic;
namespace p19Lista2
{
    class Program
    {
        static void Main(string[] args)
        {
           //Crear una lista con elementos del tipo Pieza
           List<Pieza> mp = new List<Pieza>();
           //agregar peizas a la lista
           mp.Add(new Pieza(1234,"Tarjeta Grafica"));
           mp.Add(new Pieza(2104,"Memoria Ram"));
           mp.Add(new Pieza(1678,"Disco Duro"));
           //Agregar un rango de piezas
           var provedor = new List<Pieza>(){
               new Pieza(9879,"Fuente de poder"),
               new Pieza(5978,"Gabinete Cooler Master"),
               new Pieza(9879,"Disipador de calor"),
           };

           mp.AddRange(provedor);

           // usar el metodo FOREACH integrado en la lista para imprimir su contenido

           mp.ForEach(p=>Console.WriteLine(p.ToString()));

           //Eliminar el ultimo elemento de la lista

           mp.RemoveAt(mp.Count-1);

           // insertar elemento en un espacio especifico (segunda posicion)
           Console.WriteLine("Se inserta elemento en la posicion 2");
           mp.Insert(1,new Pieza(2232,"Caja de ventiladores"));

           mp.ForEach(p=>Console.WriteLine(p.ToString()));

           // Buscar todas las ocurrencias de la palabara tornillo
           Console.WriteLine("Piezas que contienen la palabra Tarjeta");
           var pzas = mp.FindAll(p=>p.Nombre.Contains("Tarjeta"));
           pzas.ForEach(p=>Console.WriteLine(p.ToString()));
           // Buscar todas las piezas que su id es menor de 5000
           Console.WriteLine("Buscar todas las piezas que su id es menor de 5000");
           
           var pzasId = mp.FindAll(p=>p.Id<5000);//Este es como un where------------------------------------

           pzasId.ForEach(p=>Console.WriteLine(p.ToString()));
           
        }
    }
}
