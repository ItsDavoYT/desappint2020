using System;
using System.Collections.Generic;

namespace pExamenParcial1{

    class Red{

        public string empresa{get;set;}
        public string propietario{get;set;}
        public string domicilio{get;set;}
        public List<Node> nodos;
        public override string ToString() => $"\nEmpresa         :     {empresa}\n"+
                                             $"Propietario     :     {propietario}\n"+
                                             $"Domicilio       :     {domicilio}\n";
        //public List<Vulnerabilidad> Vul;

    }

}