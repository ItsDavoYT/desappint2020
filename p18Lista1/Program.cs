using System;
using System.Collections.Generic;

namespace p18Lista1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Definir la lista con valores iniciales
            List<string> mats = new List<string>(){
                "Calculo I",
                "Redaccion Avanzada",
                "Introduccion a la Ingenieria"
            };

            //agregar elementos a la lista

            mats.Add("Matematicas Discretas");
            mats.Add("Compiladores e Interpretadores");


            imprime(mats);

            // Agregar  un rango de materias
            Console.WriteLine("----");
            string[] mopt = {

                "Seguridad en Redes y Sistemas (op)",
                "Topicos selector de Redes (op)",
                "Criptografia Avanzada (op)"

            };
            mats.AddRange(mopt);

            imprime(mats);

            //Ordenar la Lista

            mats.Sort();

            imprime(mats);

            //Invertir los elementos de la lista
            Console.WriteLine("----");
            mats.Reverse();
            imprime(mats);

            //Buscar un elemento en la lista, en base a una condiccion  
            Console.WriteLine("----");
            Console.WriteLine("Materias que tengan la palabra Discretas"); 
            string mat = mats.Find(x => x.Contains("Discretas"));         
            Console.WriteLine(mat);

            //Buscar todas las materias en la lista, que son optativas
            Console.WriteLine("----");
            Console.WriteLine("Materias optativas");
            var ms = mats.FindAll(x=>x.Contains("(op)"));
            imprime(ms);

        }

        static void imprime(List<string> lista){

            //Vercion para imprimir listas normal

            //foreach(string m in lista){
              //  Console.WriteLine(m);
            //}

            //ultra reducida
            lista.ForEach(m=>Console.WriteLine(m));

            Console.WriteLine("");
        }

    }
}
