using System;

namespace p15cuentabancariav1
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco mibanco = new Banco("El cochinito","Carlos Castaneda");

            mibanco.AgregarCliente(new Cliente("Juan Camaney"));
            mibanco.AgregarCliente(new Cliente("Jessica Alba"));
            mibanco.AgregarCliente(new Cliente("Tony Soprano"));
            mibanco.AgregarCliente(new Cliente("Jack Bauer"));

            mibanco.Clientes[0].Cuenta = new CuentaBancaria(100);
            mibanco.Clientes[1].Cuenta = new CuentaBancaria(200);
            mibanco.Clientes[2].Cuenta = new CuentaBancaria(300);
            mibanco.Clientes[3].Cuenta = new CuentaBancaria(0);
            mibanco.Clientes[2].Cuenta.Retira(100);
            mibanco.Clientes[3].Cuenta.Deposita(50);

            Console.WriteLine("Reporte General \n");
            Console.WriteLine($"Banco {mibanco.Nombre} propiedad de {mibanco.Propietario} \n");

            foreach(Cliente cte in mibanco.Clientes) {
                Console.WriteLine($"El cliente de nombre {cte.Nombre}");
                Console.WriteLine($"Tiene una cuenta con un saldo de {cte.Cuenta.Saldo}");
            }       
        }
    }
}
