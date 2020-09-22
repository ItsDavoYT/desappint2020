using System;
using System.Collections.Generic;
using System.Linq;

namespace p21Linq2 {

    class Program {
    
        static void Main(string[] args) {
                
                string[] frutas = new string[]{"pera","melon","sandia","platano","fresa","tomate","naranja","limon","toronja","pepino","manzana"};

                var qryFrutasM = (from f in frutas where f.StartsWith('m') select f).ToList();

                Console.WriteLine($"\nFrutas que inician con la letra m: {qryFrutasM.Count()}\n");

                qryFrutasM.ForEach(m=>Console.WriteLine($"{m} "));

                Console.WriteLine("--------------------");

                var qryFrutasAN = (from f in frutas where f.Contains("an") select f).ToList();

                Console.WriteLine($"\nFrutas que contienen la letra an : {qryFrutasAN.Count()}\n");

                qryFrutasAN.ForEach(an=>Console.WriteLine($"{an} "));

                Console.WriteLine("--------------------");

                var qryFrutasA = (from f in frutas where f.EndsWith('a') select f).ToList();

                Console.WriteLine($"\nFrutas que terminan con la letra a : {qryFrutasA.Count()}\n");

                qryFrutasA.ForEach(a=>Console.WriteLine($"{a} "));

                Console.WriteLine("--------------------");

        }
    }
}
