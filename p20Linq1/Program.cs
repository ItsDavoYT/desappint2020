using System;
using System.Collections.Generic;
using System.Linq;

namespace p20Linq1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fuente de datos

            int[] numeros = new int[]{10,25,-1,10,0,320,22,65,800,-4,20,20,1000,2000,-233};

            // crear la consulta (puede ser un solo renglon)
            IEnumerable<int> qrypares =
                from num in numeros
                where (num%2)==0
                select num;

            // ejecutar consulta
            Console.WriteLine($"\nNumeros Pares {qrypares.Count()}");

            foreach(int n in qrypares){
                Console.Write($"{n} ");
            }

            Console.Write("-------------------------");

            // crear consulta impares (la creo en un solo renglon) si le ponemos var crea el tipo de datos que regresa el LINQ (regresa un IEnumerable) 
            // pero con el .ToArray lo combierte a un arreglo comun
            // con el .ToList se puede hacer una lista

            var qryimpares = (from num in numeros where (num%2)!=0 select num).ToArray();

            Console.WriteLine($"\nNumeros imPares {qryimpares.Count()}");

            foreach(int i in qryimpares){
                Console.Write($"{i} ");
            }


            Console.Write("-------------------------");

            // crear consulta para sacar los numeros mayores a 100 y ponerlos en una lista

            var qryMayoresACien = (from num in numeros where num>100 select num).ToList();

            Console.WriteLine($"\nNumeros Mayores a cien {qryMayoresACien.Count()}");

            qryMayoresACien.ForEach(c=>Console.Write($"{c} "));


            Console.Write("-------------------------");
            //foreach(int c in qryMayoresACien){
              //  Console.Write($"{c} ");
            //}




        }
    }
}
