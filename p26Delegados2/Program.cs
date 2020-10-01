// Ejemplo de delegado multicast un delegado que invoca varios metodos al mismo tiempo

using System;

namespace p26Delegados2
{

    public delegate void Midelegado(string msj);

    class Program
    {
        static void Main(string[] args)
        {
            Midelegado d1,d2,d3,d;
            d1 = Mensajes.Mensaje1;
            d2 = Mensajes.Mensaje2;
            d = d1 + d2;
            d("El peje");
            d3= (string msj) => Console.WriteLine($"{msj} - paga todo que no pare la fiesta");
            d += d3;
            d("El borolas");
            d -=d2;
            d("Peña");
        }
    }
}
