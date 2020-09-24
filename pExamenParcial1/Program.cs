﻿//Examen Parcial 1
//David Rodriguez de la Cruz
//24/09/2020


using System;
using System.Collections.Generic;
using System.Linq;
//considerando para hacer los calculos de la fecha que estamos en 2018
namespace pExamenParcial1{

    class Program{

        static void Main(string[] args){

            //se crean las vulnerabilidades de cada nodo en una lista por separado para dejar mas limpio el codigo

            //se crea una fecha con el año 2018 (para que los resultados coincidan con los esperados) para poder hacer el calculo de antiguedad
            DateTime fecha2018 = new DateTime(2018,1,1);

            var vulIp1 = new List<Vulnerabilidad>{
                    
                    new Vulnerabilidad{clave="CVE-2015-1635",vendedor="microsoft",Descripcion="HTTP.sys permite a atacantes remotos ejecutar código arbitrario",
                                        tipo="remota",fecha=new DateTime(2015,04,14),antiguedad = calcularDiferencia(new DateTime(2015,04,14),fecha2018)},   
                    new Vulnerabilidad{clave="CVE-2017-0004",vendedor="microsoft",Descripcion="El servicio LSASS permite causar una denegación de servicio",
                                        tipo="local",fecha=new DateTime(2017,01,10), antiguedad = calcularDiferencia(new DateTime(2017,10,01),fecha2018)}   
            };

            var vulIp2 =  new List<Vulnerabilidad>{
                    
                    new Vulnerabilidad{clave="CVE-2017-3847",vendedor=" cisco",Descripcion="Cisco Firepower Management Center XSS",
                                        tipo="remota",fecha=new DateTime(2017,02,21),antiguedad = calcularDiferencia(new DateTime(2017,02,21),fecha2018)}
            };

            var vulIp3 = new List<Vulnerabilidad>{
                    
                    new Vulnerabilidad{clave="CVE-2009-2504",vendedor="microsoft",Descripcion="Múltiples desbordamientos de enteros en APIs Microsoft .NET 1.1",
                                        tipo="local",fecha=new DateTime(2009,11,13),antiguedad = calcularDiferencia(new DateTime(2009,11,13),fecha2018)},
                    new Vulnerabilidad{clave="CVE-2016-7271",vendedor="microsoft",Descripcion="Elevación de privilegios Kernel Segura en Windows 10 Gold",
                                        tipo="local",fecha=new DateTime(2016,12,20),antiguedad = calcularDiferencia(new DateTime(2016,12,20),fecha2018)},
                    new Vulnerabilidad{clave="CVE-2017-2996",vendedor="adobe",Descripcion="Adobe Flash Player 24.0.0.194 corrupción de memoria explotable",
                                        tipo="remota",fecha=new DateTime(2017,02,15),antiguedad = calcularDiferencia(new DateTime(2017,02,15),fecha2018)}
            };

            //se crea cada nodo como el ultimo nodo no tiene vulnerabilidades se crea sola la lista
            

            List<Node> Listanodos = new List<Node>(){

                new Node{ip="192.168.0.10",Tipo="servidor",Puertos=5,Saltos=10,So="linux",Vul = vulIp1, totalVulnerabilades = vulIp1.Count()},

                new Node{ip="192.168.0.12",Tipo="equipoactivo",Puertos=2,Saltos=12,So="ios",Vul = vulIp2 , totalVulnerabilades = vulIp2.Count()},

                new Node{ip="192.168.0.20",Tipo="computadora",Puertos=8,Saltos=5,So="windows",Vul = vulIp3 , totalVulnerabilades = vulIp3.Count()},

                new Node{ip="192.168.0.15",Tipo="servidor",Puertos=10,Saltos=22,So="linux",Vul = new List<Vulnerabilidad>{}, totalVulnerabilades = 0}



            };

            //se crea la red con que vamos a utilizar y se agregan todos los nodos a la red

            Red red = new Red{empresa="Red Patito, S.A. de C.V.", propietario="Mr Pato Macdonald",domicilio="Av. Princeton 123, Orlando Florida", nodos = Listanodos};
            

            // Comienza las consultas y el mostrar los datos en pantalla -------------------------------


            Console.WriteLine("\n>> Datos generales de la red:");
            Console.WriteLine(red.ToString());

            //Calcular el total de nodos en la red

            Console.WriteLine($"Total nodos red           : {red.nodos.Count()}");
            
            //se obtiene una lista (usando linq) con el total de vulnerabilidades en formato IEnumerable pero se transforma a list que lo regresa en forma de string
            //entonces se hace transforma en una segunda lista donde se hace el parse a int para poder sumar los elementos de la lista

            var totalVulString = (from vul in Listanodos select $"{vul.Vul.Count()}").ToList();
            var totalVulInt = totalVulString.Select(int.Parse).ToList();
            
                //totalVulInt.ForEach(x=>Console.WriteLine(x));
            
            //Calculando el total de vulnerabilidades

            Console.WriteLine($"Total vulnerabilidades    : {totalVulInt.Sum()}");
            
            //Consultado los datos generales de los nodos
            Console.WriteLine("\n>> Datos generales de los nodos:\n");

            Listanodos.ForEach(x=>Console.WriteLine(x));

            //Calculando el mayor/menor numero de saltos

            //Tambien se puede obtener una lista haciendo el parse
            var TotalSaltos =(from may in Listanodos select $"{may.Saltos}").Select(int.Parse).ToList();
            Console.WriteLine($"\nMayor numero de saltos:  {TotalSaltos.Max()}");
            Console.WriteLine($"Menor numero de saltos:  {TotalSaltos.Min()}");
            
            //se imprimen las vulnerabilidades por nodo si es que estas lo contienen.
            Console.WriteLine($"\n>> Vulnerabilidades por nodo:");
            
            //doble foreach anidado
            foreach(var nodo in Listanodos){
                Console.WriteLine($"\n> Ip: {nodo.ip}, Tipo: {nodo.Tipo}");
                if(nodo.Vul.Count() != 0){
                    Console.WriteLine("\nVulnerabilidades:\n");
                    foreach(var vul in nodo.Vul){
                        Console.WriteLine(vul.ToString()+"\n");
                    }
                }else{
                    Console.WriteLine("\nNo tiene vulnerabilidades ..\n");
                }
            }

        }

        //se  calcula la diferencia de años entre dos fechas dadas

        static int calcularDiferencia(DateTime inicio, DateTime final){
           
           return (final.Year - inicio.Year)+ 
                  (((final.Month > inicio.Month) || ((final.Month == inicio.Month) && (final.Day >= inicio.Day))) ? 1:0);
        
        }


    }
}
