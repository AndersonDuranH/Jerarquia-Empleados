using System;

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
            ColaEmpleados cola = new ColaEmpleados();
            cola.Push(Presidente);

            while (!cola.EstaVacia())
            {
                Empleado actual = cola.Pop();

                if (actual.CantSubordinados < 2)
                {
                    actual.Subordinados[actual.CantSubordinados] = nuevo;
                    actual.CantSubordinados++;

                    Console.WriteLine($"Empleado {nuevo.Nombre} agregado bajo {actual.Nombre}");
                    return;
                }

                for (int i = 0; i < actual.CantSubordinados; i++)
                {
                    cola.Push(actual.Subordinados[i]);
                }
            }
        }

        public void ProcesoRevision(Empleado actual)
        {
            if (actual == null) return;

            for (int i = 0; i < actual.CantSubordinados; i++)
            {
                ProcesoRevision(actual.Subordinados[i]);
            }

            for (int i = 0; i < actual.CantSubordinados; i++)
            {
                Empleado sub = actual.Subordinados[i];

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

            for (int i = 0; i < n.CantSubordinados; i++)
            {
                Imprimir(n.Subordinados[i], nivel + 1);
            }
        }
    }
}
