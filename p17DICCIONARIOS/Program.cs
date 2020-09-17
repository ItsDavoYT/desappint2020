using System;
using System.Collections.Generic;

namespace p17DICCIONARIOS
{
    class Program
    {
        static void Main(string[] args)
        {
            //Se define el diccionario y se reserva el espacio en la memoria
            //Dictionary<string,string> midic= new Dictionary<string, string>();
            SortedDictionary<string,string> midic= new SortedDictionary<string, string>();
            //Agregar elementos al diccionario
            midic.Add("txt","Archivo De texto");
            midic.Add("jpg","Archivo De imagen");
            midic.Add("mp3","Archivo De sonido");
            midic.Add("gif","Archivo De imagen que se mueve");
            midic.Add("html","Archivo De texto html");
            midic.Add("exe","Archivo De ejecutable");
            midic.Add("lll","Archivo De tipo desconocido");

            //accediendo desde la llave
            Console.WriteLine(midic["html"]);

            //verificar si una llave existe, si no agregarla
            if(midic.ContainsKey("elf")){
                Console.WriteLine("La llave ya existe en el diccionario");
            }else{
                midic.Add("elf","Archivo ejecutable en linux");
            }

            //borrar una entrada al diccionario en base a la llave

            if(midic.ContainsKey("lll")){
                midic.Remove("lll");
            }

            // Recorrer el diccionario e imprimir la llave y su valor

            foreach(KeyValuePair<string,string> val in midic){
                Console.WriteLine($"{val.Key} - {val.Value}");
            }

            //Imprimir solo las llaves del diccionario

            foreach(string key in midic.Keys){
                Console.WriteLine($"{key}");
            }

            //Imprimir solo las llaves del diccionario

            foreach(string val in midic.Values){
                Console.WriteLine($"{val}");
            }

            //Borrar todas las entradas del diccionario

            midic.Clear();

        }
    }
}
