using System;
using System.Collections.Generic;

namespace Jerarquia
{
    public class Empleado
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public TablaHashContactos Directorio { get; set; }
        public List<Empleado> Subordinados { get; set; }

        public Empleado(string cod, string nom, string ape, int ed)
        {
            Codigo = cod;
            Nombre = nom;
            Apellido = ape;
            Edad = ed;
            Directorio = new TablaHashContactos(50);
            Subordinados = new List<Empleado>();
        }

        public int ObtenerEsfuerzo()
        {
            return Directorio.NumElementos;
        }

        public override string ToString()
        {
            return $"[{Codigo}] {Nombre} {Apellido} (Esfuerzo: {ObtenerEsfuerzo()})";
        }
    }
}
