using System;
using System.Collections.Generic;

namespace pExamenParcial1{

    class Node{

        public string ip{get;set;}
        public string Tipo{get;set;}
        public int Puertos{get;set;}
        public int Saltos{get;set;}
        public string So{get;set;}
        public List<Vulnerabilidad> Vul;
        public override string ToString() => $"Ip: {ip},   Tipo: {Tipo},   Puertos: {Puertos},   Saltos: {Saltos},   SO: {So}";
        

    }


}