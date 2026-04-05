using System;
using System.Collections.Generic;

namespace Jerarquia
{
    public class ArbolJerarquia
    {
        public Empleado Presidente { get; private set; }

        public ArbolJerarquia(Empleado presi)
        {
            Presidente = presi;
        }

        public void AgregarEnHoja(Empleado nuevo)
        {
            Queue<Empleado> cola = new Queue<Empleado>();
            cola.Enqueue(Presidente);

            while (cola.Count > 0)
            {
                Empleado actual = cola.Dequeue();

                if (actual.Subordinados.Count < 2)
                {
                    actual.Subordinados.Add(nuevo);
                    Console.WriteLine($"Empleado {nuevo.Nombre} agregado bajo {actual.Nombre}");
                    return;
                }

                foreach (var sub in actual.Subordinados)
                    cola.Enqueue(sub);
            }
        }

        public void ProcesoRevision(Empleado actual)
        {
            if (actual == null) return;

            foreach (var sub in actual.Subordinados)
                ProcesoRevision(sub);

            foreach (var sub in actual.Subordinados)
            {
                if (sub.ObtenerEsfuerzo() > actual.ObtenerEsfuerzo())
                {
                    Console.WriteLine($"ASCENSO: {sub.Nombre} supera a {actual.Nombre}");
                    IntercambiarDatos(actual, sub);
                }
            }
        }

        private void IntercambiarDatos(Empleado a, Empleado b)
        {
            string tempNom = a.Nombre; a.Nombre = b.Nombre; b.Nombre = tempNom;
            string tempApe = a.Apellido; a.Apellido = b.Apellido; b.Apellido = tempApe;
            string tempCod = a.Codigo; a.Codigo = b.Codigo; b.Codigo = tempCod;

            var tempHash = a.Directorio;
            a.Directorio = b.Directorio;
            b.Directorio = tempHash;
        }

        public void Imprimir(Empleado n, int nivel)
        {
            if (n == null) return;

            Console.WriteLine(new string(' ', nivel * 4) + "|-- " + n.ToString());

            foreach (var sub in n.Subordinados)
                Imprimir(sub, nivel + 1);
        }
    }
}
