using System;

namespace p24Interfaz2
{

    public class Organismo{
        public void Respiracion() => Console.WriteLine("Respiracion");
        public void Movimiento()=> Console.WriteLine("Movimiento");
        public void Crecimiento() => Console.WriteLine("Crecimiento");
    }

    public interface IAnimales{
        void Multicelulares();
        void SangreCaliente();
    }

    public interface ICanino : IAnimales{
        void Correr();
        void Cuatropatas();
    }

    public interface IPajaro : IAnimales{
        void Volar();
        void Dospatas();
    }

    public class Perro:Organismo ,ICanino{
        public void Multicelulares() => Console.WriteLine("Multicelular perro");
        public void SangreCaliente() => Console.WriteLine("Sangrecaliente perro");
        public void Correr() => Console.WriteLine("Correr perro");
        public void Cuatropatas() => Console.WriteLine("Cuatropatas perro");
    }

    public class Perico:Organismo, IPajaro{
        public void Multicelulares() => Console.WriteLine("Multicelular perico");
        public void SangreCaliente() => Console.WriteLine("Sangrecaliente perico");
        public void Volar()=> Console.WriteLine("Volar perico");
        public void Dospatas()=> Console.WriteLine("Dospatas");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSegundo Ejemplo de Interfaces \n");

            Perro miperro = new Perro();
            Console.WriteLine("\nCaracteristicas del Perro: ");
            miperro.Respiracion();
            miperro.Movimiento();
            miperro.Crecimiento();
            miperro.Multicelulares();
            miperro.SangreCaliente();
            miperro.Correr();
            miperro.Cuatropatas();

            Perico miperico = new Perico();
            Console.WriteLine("\nCaracteristicas del perico\n");
            miperico.Respiracion();
            miperico.Movimiento();
            miperico.Crecimiento();
            miperico.Multicelulares();
            miperico.SangreCaliente();
            miperico.SangreCaliente();
            miperico.Volar();
            miperico.Dospatas();
        }
    }
}
