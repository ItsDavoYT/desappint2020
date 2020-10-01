//Ejemplo de delegado simple

using System;

namespace p25Delegados1
{

    public delegate void MiDelegado(string msj);

    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado d;
            d=Mensaje.Mensaje1;
            d("Juan");
            d = Mensaje.Mensaje2;
            d("Jose");
            d = (string msj) => Console.WriteLine($"{msj} - paga todo que no pare la fiesta");
            d("Carlos");
            
        }
    }


    public class Mensaje {
        public static void Mensaje1(string msj) => Console.WriteLine($"{msj} - lleva el pastel");
        public static void Mensaje2(string msj) => Console.WriteLine($"{msj} - fue el culpable se cancela la fiesta");
    }



}
