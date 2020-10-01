//Ejemplo de delegado generico

using System;

namespace p28Delegados4
{

    public delegate T Suma<T>(T p1, T p2);

    class Program
    {
        static void Main(string[] args)
        {
            Suma<int> d1 = Sumar;
            Suma<string> d2 = Concatenar;
            //Suma<string> d3 = NoSePuede; <--- Esto no se puede diferentes tipos de parametros

            Console.WriteLine($"La suma es {d1(20,30)}");
            Console.WriteLine($"La concatenacion es: {d2("Hola mundo"," cruel")}");
            Console.WriteLine($"Diferentes tipos de parametros : {NoSePuede("Parametro a: ",100)}");

        }

        public static int Sumar(int a, int b) => a+b;
        public static string Concatenar(string a, string b) => a+b;
        public static string NoSePuede(string a, int b) => $"{a} - {b.ToString()}";


    }
}
