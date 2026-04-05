using Jerarquia;

public class NodoEmpleado
{
    public Empleado dato;
    public NodoEmpleado siguiente;

    public NodoEmpleado(Empleado valor)
    {
        dato = valor;
        siguiente = null;
    }
}
