using System;

namespace p23Interfaz1
{

    public interface IAnimal
    {
        string Nombre{get;set;}
        void Lloarar();
    }

    class Perro: IAnimal{

        public Perro(string nombre) => Nombre = nombre;
        public string Nombre{get;set;}
        public void Lloarar() => Console.WriteLine("Woff Woff");

    }

    class Gato : IAnimal{
        public Gato(string nombre) => Nombre = nombre;
        public string Nombre{get;set;}
        public void Lloarar() => Console.WriteLine("Miau Miau");
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Primer ejemplo de uso de interfaces\n");
            Perro miperro = new Perro("Sabueso");
            Console.WriteLine($"El perro {miperro.Nombre}");
            miperro.Lloarar();

            Gato migato = new Gato("Misifu");
            Console.WriteLine($"El gato {migato.Nombre}");
            migato.Lloarar();


        }
    }
}
