using System;

namespace Jerarquia
{
    

    public class ColaEmpleados
    {
        private NodoEmpleado cima;
        private NodoEmpleado cola;

        public ColaEmpleados()
        {
            cima = null;
            cola = null;
        }

        public bool EstaVacia()
        {
            return cima == null;
        }

        
        public void Push(Empleado valor)
        {
            NodoEmpleado nuevoNodo = new NodoEmpleado(valor);

            if (cima == null)
            {
                cima = cola = nuevoNodo;
            }
            else
            {
                cola.siguiente = nuevoNodo;
                cola = nuevoNodo; 
            }
        }

        
        public Empleado Pop()
        {
            NodoEmpleado aux = cima;

            if (aux != null)
            {
                cima = cima.siguiente;
                aux.siguiente = null;
                return aux.dato;
            }

            return null;
        }

        public void Imprimir()
        {
            if (cima == null)
            {
                Console.WriteLine("La cola está vacía");
                return;
            }

            NodoEmpleado aux = cima;

            while (aux != null)
            {
                Console.Write($"{aux.dato} -> ");
                aux = aux.siguiente;
            }

            Console.WriteLine("Null");
        }
    }
}
