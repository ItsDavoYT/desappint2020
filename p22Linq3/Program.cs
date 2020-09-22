using System;
using System.Collections.Generic;
using System.Linq;

namespace p22Linq3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Estudiante> estudiantes = new List<Estudiante>(){
                new Estudiante{Matricula=35161769,Nombre="David Rodriguez", Domicilio="Bisnaga #302, Calera Zac.", Califs = new List<float>{7,8,8,10} },
                new Estudiante{Matricula=35161769,Nombre="Francisco Javier", Domicilio="Luis Moya, Zacatecas Zac.", Califs = new List<float>{7,7,7,8} },
                new Estudiante{Matricula=35161770,Nombre="Alan Fernando", Domicilio="Unkown", Califs = new List<float>{8,8,9,10} },
                new Estudiante{Matricula=35161770,Nombre="Jonatan Alejandro", Domicilio="Bicentenario #200, Zacatecas Zac.", Califs = new List<float>{8,7,8,7} },
                new Estudiante{Matricula=34161769,Nombre="Juan Pablo Castillo", Domicilio="Casa UAZ #403 Guadalupe Zac.", Califs = new List<float>{7,8,7,9} },
            };

            estudiantes.Add(new Estudiante{Matricula=38112233,Nombre="Cecilia Rodriguez", Domicilio="Bisnaga #302, Calera Zac.", Califs = new List<float>{7,7,7,7}});

            // Todos los registros sin ninguna consulta o filtro 
            
            Console.WriteLine(($"\nTodos los estudiantes: {estudiantes.Count()}"));

            estudiantes.ForEach(est=> Console.WriteLine(est.ToString()));

            // Filtrar los estudiantes que son de zacatecas

            Console.WriteLine("------------");

            var estzac = (from estZaca in estudiantes where estZaca.Domicilio.Contains("Zacatecas") select estZaca).ToList();

            Console.WriteLine(($"\nTodos los estudiantes de zacatecas: {estzac.Count()}"));

            estzac.ForEach(estZ=>Console.WriteLine(estZ.ToString()));

            // Filtrar los estudiantes con promedio de 8 y mostrar ordenados por nombre descendente

            Console.WriteLine("------------");

            var otros =(from est in estudiantes where est.Califs.Average()>=8 orderby est.Nombre descending select est).ToList();

            Console.WriteLine(($"\nTodos los estudiantes de promedio de 8 ordenados de nombre decendente: {otros.Count()}"));

            otros.ForEach(est=>Console.WriteLine($"{est}"));

            // Consulta con datos Agrupados

            Console.WriteLine("------------");
            
            var valMatricula =(from est in estudiantes group est by est.Matricula);

            Console.WriteLine(("\nTodos los estudiantes de agrupados por matriculas\n"));

            foreach(var gpo in valMatricula){
                Console.WriteLine(gpo.Key);
                foreach(Estudiante est in gpo){
                    Console.WriteLine(est.ToString());
                }
                Console.WriteLine("\n");
            }

            // Estudiante y sus promedios

            Console.WriteLine("------------");

            Console.WriteLine("\n Lista de alumnos y sus promedios\n");

            var proms =(from est in estudiantes select $"Nombre: {est.Nombre}  | Promedio Calificaciones: {est.Califs.Average()}").ToList();
            
            proms.ForEach(p=>Console.WriteLine(p));

        }
    }
}
