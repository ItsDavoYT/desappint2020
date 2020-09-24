using System;

namespace pExamenParcial1{

    class Vulnerabilidad{

        public string clave{get;set;}
        public string vendedor{get;set;}
        public string Descripcion{get;set;}
        public string tipo{get;set;}
        public DateTime fecha{get;set;}

        public override string ToString() => $"Clave: {clave},   Vendedor: {vendedor},   Descripcion: {Descripcion},   "+
                                             $"Tipo: {tipo},   Fecha: {fecha.ToString("MM/dd/yyyy")}";

    }



}