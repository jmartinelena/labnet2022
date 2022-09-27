using Practica.EF.Common.Exceptions;
using Practica.EF.Entities;
using Practica.EF.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.UI
{
    public class Program
    {
        // Esta consola es horrible pero no se me ocurre como hacer un elemento logic que sirva para cualquier tabla que herede 
        // de BaseLogic y asi evitar tener que hacer un if por cada tabla. Ahora safo porque uso 2 tablas nomas pero si
        // usara mas seria muy problematico a la hora de escalarlo. Nomas se me ocurre "perder" lo generico en BaseLogic
        // y para toda tabla devolver strings (o listas de strings) con la info porque esto es al fin y al cabo una app de consola.
        // O sino hacer una interfaz no generica que implemente la interfaz generica o una cosa asi.
        static void Main(string[] args)
        {
            ILogic<Customers> cl = new CustomerLogic();

            ILogic<Employees> el = new EmployeeLogic();
            
            Console.Write("Con que tabla queres trabajar?");
            Console.Write("\n\t1 - ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Customers");
            Console.ResetColor();
            Console.Write("\n\t2 - ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Employees");
            Console.ResetColor();
            Console.Write("\n\t3 - ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Ninguna (salir del programa)");
            Console.ResetColor();

            // Este esta escrito horriblemente
            while (true)
            {
                Console.Write("\n--------------------------------------");
                Console.Write("\nEligiendo tabla -  Ingresa el numero correspondiente a tu eleccion: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string tabla = Console.ReadLine();
                Console.ResetColor();

                if (tabla != "1" && tabla != "2" && tabla != "3")
                {
                    Console.Write("Eleccion invalida. Intente de nuevo.");
                    continue;
                }
                if (tabla == "3")
                {
                    Console.Write("Programa terminado. Presione cualquier tecla para salir.");
                    break;
                }

                while (true)
                {
                    Console.Write("--------------------------------------");
                    Console.Write("\nEstas trabajando en ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(tabla == "1" ? "Customers" : "Employees");
                    Console.ResetColor();
                    
                    Console.Write("\nQue deseas hacer?");
                    Console.Write("\n\t1 - Traer todos los datos.");
                    Console.Write("\n\t2 - Traer los datos de un pais especifico.");
                    Console.Write("\n\t3 - Traer los datos de un ID especifico.");
                    Console.Write("\n\t4 - Agregar un registro a la tabla.");
                    Console.Write("\n\t5 - Actualizar un registro en la tabla.");
                    Console.Write("\n\t6 - Borrar un registro en la tabla.");
                    Console.Write("\n\t7 - Salir de la tabla.");
                    
                    Console.Write("\nIngrese el numero correspondiente a su eleccion: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string input = Console.ReadLine();
                    Console.ResetColor();

                    string[] inputsValidos = new string[] { "1", "2", "3", "4", "5", "6", "7" };

                    if (!inputsValidos.Contains(input))
                    {
                        Console.WriteLine("Eleccion invalida. Intente de nuevo.");
                        continue;
                    }
                    if (input == "7")
                    {
                        Console.WriteLine("Volviendo al menu anterior.");
                        break;
                    }

                    if (input == "1") // GetAll
                    {
                        Console.WriteLine("\nTrayendo todos los datos: ");
                        Console.WriteLine();

                        if (tabla == "1")
                        {
                            foreach (var customer in cl.GetAll())
                            {
                                Console.WriteLine($"\t {customer}");
                            }
                        }
                        else
                        {
                            foreach(var employee in el.GetAll())
                            {
                                Console.WriteLine($"\t {employee}");
                            }
                        }
                        
                        Console.WriteLine();
                        continue;
                    }

                    if (input == "2") // GetByCountry
                    {
                        Console.Write("De que pais? ");
                        string country = Console.ReadLine();
                        Console.WriteLine();
                        
                        if (tabla == "1")
                        {
                            try
                            {
                                foreach (var customer in cl.GetByCountry(country))
                                {
                                    Console.WriteLine($"\t {customer}");
                                }
                            }
                            catch (BadCountryException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                        }
                        else
                        {
                            try
                            {
                                foreach (var employee in el.GetByCountry(country))
                                {
                                    Console.WriteLine($"\t {employee}");
                                }
                            }
                            catch (BadCountryException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                        }

                        Console.WriteLine();
                        continue;
                    }

                    if (input == "3") // GetById
                    {
                        Console.Write("Ingrese un id: ");
                        string id = Console.ReadLine();
                        Console.WriteLine();

                        if (tabla == "1")
                        {
                            try
                            {
                                var customer = cl.GetById(id);
                                Console.WriteLine($"\t {customer}");
                            }
                            catch (BadIDException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Los IDs de esta tabla son strings de 5 caracteres.");
                            }
                        }
                        else
                        {
                            try
                            {
                                var employee = el.GetById(id);
                                Console.WriteLine($"\t {employee}");
                            }
                            catch (BadIDException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Los IDs de esta tabla son numeros enteros.");
                            }
                        }

                        Console.WriteLine();
                        continue;
                    }

                    if (input == "4") // Add
                    {
                        if (tabla == "1")
                        {
                            Console.Write("\n\tIngrese el valor del campo CustomerID: ");
                            string customerId = Console.ReadLine();
                            Console.Write("\n\tIngrese el valor del campo CompanyName: ");
                            string companyName = Console.ReadLine();

                            try
                            {
                                cl.Add(new Customers() { CustomerID = customerId, CompanyName = companyName});
                            }
                            catch (InvalidCustomerException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                            catch (CustomerAlreadyInException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                        }
                        else
                        {
                            // No pongo el id porque es autoincremental y a la BD no le importa cual le pase
                            Console.Write("\n\tIngrese el valor del campo LastName: ");
                            string lastName = Console.ReadLine();
                            Console.Write("\n\tIngrese el valor del campo FirstName: ");
                            string firstName = Console.ReadLine();

                            try
                            {
                                el.Add(new Employees() { LastName = lastName, FirstName = firstName });
                            }
                            catch (InvalidEmployeeException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                            catch (EmployeeAlreadyInException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                        }
                        
                        Console.WriteLine();
                        continue;
                    }

                    if (input == "5") // Update
                    {
                        if (tabla == "1")
                        {
                            // Aca considero que un string numerico (ej: "12345") es tecnicamente valido.
                            Console.Write("\n\tIngrese el valor de CustomerID del registro a modificar: ");
                            string customerId = Console.ReadLine();
                            Console.Write("\n\tIngrese el nuevo valor del campo CompanyName: ");
                            string companyName = Console.ReadLine();

                            try
                            {
                                cl.Update(new Customers() {CustomerID = customerId, CompanyName = companyName });
                            }
                            catch (InvalidCustomerException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                            catch (BadIDException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                            catch (CantUpdateDueToFKException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                        }
                        else
                        {
                            Console.Write("\nIngrese el valor del EmployeeID del registro a modificar: ");
                            string employeeId = Console.ReadLine();
                            Console.Write("\n\tIngrese el valor del campo LastName: ");
                            string lastName = Console.ReadLine();
                            Console.Write("\n\tIngrese el valor del campo FirstName: ");
                            string firstName = Console.ReadLine();

                            try
                            {
                                if (!int.TryParse(employeeId, out _)) throw new InvalidEmployeeException();
                                el.Update(new Employees() { EmployeeID = int.Parse(employeeId), LastName = lastName, FirstName = firstName});
                            }
                            catch (InvalidEmployeeException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                            catch (BadIDException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                            catch (CantUpdateDueToFKException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                        }

                        Console.WriteLine();
                        continue;
                    }

                    if (input == "6") // Delete
                    {
                        if (tabla == "1")
                        {
                            Console.Write("\n\tIngrese el valor de CustomerID del registro a eliminar: ");
                            string customerId = Console.ReadLine();

                            try
                            {
                                cl.Delete(customerId);
                            }
                            catch (BadIDException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                            catch (CantDeleteDueToFKException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                        }
                        else
                        {
                            Console.Write("\nIngrese el valor del EmployeeID del registro a eliminar: ");
                            string employeeId = Console.ReadLine();

                            try
                            {
                                if (!int.TryParse(employeeId , out _)) throw new BadIDException(employeeId);
                                el.Delete(employeeId);
                            }
                            catch (BadIDException e )
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                            catch (CantDeleteDueToFKException e)
                            {
                                Console.WriteLine();
                                Console.WriteLine(e.Message);
                            }
                        }

                        Console.WriteLine();
                        continue;
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
