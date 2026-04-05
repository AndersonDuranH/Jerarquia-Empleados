using System;
using Jerarquia;

class Program
{
    static void Main()
    {
        Empleado presi = new Empleado("001", "Anderson", "Jefe", 30);
        ArbolJerarquia empresa = new ArbolJerarquia(presi);

        ColaEmpleados bolsa = new ColaEmpleados();
        Random r = new Random();

        
        for (int i = 0; i < 5; i++)
        {
            Empleado e = new Empleado("Fulano" + i, "Empleado" + i, "Apellido", r.Next(20, 50));

            int contactos = r.Next(1, 10);
            for (int j = 0; j < contactos; j++)
            {
                e.Directorio.Insertar(new Contacto
                {
                    Telefono = "809" + r.Next(1000000, 9999999),
                    NombreCompleto = "Contacto " + j,
                    Email = "correo@test.com",
                    Sexo = "M"
                });
            }

            bolsa.Push(e);
        }

        int opcion;

        do
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Ver jerarquia");
            Console.WriteLine("2. Agregar empleado");
            Console.WriteLine("3. Ver bolsa");
            Console.WriteLine("4. Revision");
            Console.WriteLine("5. Salir");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    empresa.Imprimir(empresa.Presidente, 0);
                    break;

                case 2:
                    if (!bolsa.EstaVacia())
                    {
                        empresa.AgregarEnHoja(bolsa.Pop());
                    }
                    else
                    {
                        Console.WriteLine("Bolsa vacia");
                    }
                    break;

                case 3:
                    bolsa.Imprimir();
                    break;

                case 4:
                    empresa.ProcesoRevision(empresa.Presidente);
                    break;
            }

        } while (opcion != 5);
    }
}