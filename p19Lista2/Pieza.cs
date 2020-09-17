using System;

namespace p19Lista2
{

    class Pieza{
        public Pieza(int id, string nombre) => (Id,Nombre)=(id,nombre);
        public int Id{get;set;}
        public string Nombre{get;set;}
        // sobrecarga del metodo ToString
        public override string ToString() => $"{Id} - {Nombre}";
    }
  


}