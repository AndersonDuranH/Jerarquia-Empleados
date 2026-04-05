using System;
using System.Collections.Generic;
using Jerarquia;

class Program
{
    static void ImprimirCola(Queue<Empleado> cola)
    {
        Console.WriteLine("\n--- BOLSA DE EMPLEO ---");
        foreach (var e in cola)
            Console.WriteLine(e.ToString());
    }

    static void Main()
    {
        Empleado presi = new Empleado("001", "Anderson", "Admin", 30);
        ArbolJerarquia empresa = new ArbolJerarquia(presi);
        Queue<Empleado> bolsaEmpleo = new Queue<Empleado>();

        Random r = new Random();

        
        for (int i = 0; i < 5; i++)
        {
            Empleado e = new Empleado("E" + i, "Empleado" + i, "Apellido", r.Next(20, 50));

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

            bolsaEmpleo.Enqueue(e);
        }

        int opcion;

        do
        {
            Console.WriteLine("\n===== MENU =====");
            Console.WriteLine("1. Ver jerarquia");
            Console.WriteLine("2. Agregar empleado desde bolsa");
            Console.WriteLine("3. Ver bolsa de empleo");
            Console.WriteLine("4. Ejecutar proceso de revision");
            Console.WriteLine("5. Salir");
            Console.Write("Opcion: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("\n--- JERARQUIA ---");
                    empresa.Imprimir(empresa.Presidente, 0);
                    break;

                case 2:
                    if (bolsaEmpleo.Count > 0)
                    {
                        var nuevo = bolsaEmpleo.Dequeue();
                        empresa.AgregarEnHoja(nuevo);
                    }
                    else
                    {
                        Console.WriteLine("No hay empleados en la bolsa.");
                    }
                    break;

                case 3:
                    ImprimirCola(bolsaEmpleo);
                    break;

                case 4:
                    Console.WriteLine("\n--- PROCESO DE REVISION ---");
                    empresa.ProcesoRevision(empresa.Presidente);
                    break;

                case 5:
                    Console.WriteLine("Saliendo...");
                    break;
            }

        } while (opcion != 5);
    }
}
