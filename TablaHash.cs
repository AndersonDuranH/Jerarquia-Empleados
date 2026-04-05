using System;

namespace Jerarquia
{
    public class Contacto
    {
        public string Telefono { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
    }

    public class TablaHashContactos
    {
        private Contacto[] tabla;
        private int tamano;
        public int NumElementos { get; private set; }

        public TablaHashContactos(int capacidad)
        {
            tamano = capacidad;
            tabla = new Contacto[tamano];
            NumElementos = 0;
        }

        private int FuncionHash(string clave)
        {
            long d = 0;
            foreach (char c in clave)
                d = d * 27 + (int)c;

            if (d < 0) d = -d;
            return (int)(d % tamano);
        }

        public void Insertar(Contacto c)
        {
            int pos = FuncionHash(c.Telefono);

            while (tabla[pos] != null && tabla[pos].Telefono != c.Telefono)
                pos = (pos + 1) % tamano;

            if (tabla[pos] == null)
            {
                tabla[pos] = c;
                NumElementos++;
            }
        }
    }
}