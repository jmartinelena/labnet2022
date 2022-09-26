using Practica.EF.Common.Exceptions;
using Practica.EF.Entities;
using Practica.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.UI
{
    public class Program
    {
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
                Console.Write("--------------------------------------");
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
                    Console.Write("\n\t4 - Salir de la tabla.");
                    
                    Console.Write("\nIngrese el numero correspondiente a su eleccion: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string input = Console.ReadLine();
                    Console.ResetColor();

                    if (input != "1" && input != "2" && input != "3" && input != "4")
                    {
                        Console.WriteLine("Eleccion invalida. Intente de nuevo.");
                        continue;
                    }
                    if (input == "4")
                    {
                        Console.WriteLine("Volviendo al menu anterior.");
                        break;
                    }

                    if (input == "1")
                    {
                        Console.WriteLine("\nTrayendo todos los datos: ");

                        if (tabla == "1")
                        {
                            foreach (var customer in cl.GetAll())
                            {
                                Console.WriteLine($"\t {customer.CustomerID} - {customer.ContactName} trabaja en {customer.CompanyName} y vive en {customer.City}, {customer.Country}.");
                            }
                        }
                        else
                        {
                            foreach(var employee in el.GetAll())
                            {
                                Console.WriteLine($"\t {employee.EmployeeID} - {employee.FirstName} {employee.LastName} vive en {employee.City}, {employee.Country}.");
                            }
                        }
                        
                        Console.WriteLine();
                        continue;
                    }

                    if (input == "2")
                    {
                        Console.Write("De que pais? ");
                        string country = Console.ReadLine();
                        
                        if (tabla == "1")
                        {
                            try
                            {
                                foreach (var customer in cl.GetByCountry(country))
                                {
                                    Console.WriteLine($"\t {customer.CustomerID} - {customer.ContactName} trabaja en {customer.CompanyName} y vive en {customer.City}, {customer.Country}.");
                                }
                            }
                            catch (BadCountryException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        else
                        {
                            try
                            {
                                foreach (var employee in el.GetByCountry(country))
                                {
                                    Console.WriteLine($"\t {employee.EmployeeID} - {employee.FirstName} {employee.LastName} vive en {employee.City}, {employee.Country}.");
                                }
                            }
                            catch (BadCountryException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        
                        continue;
                    }

                    if (input == "3")
                    {
                        Console.Write("Ingrese un id: ");
                        string id = Console.ReadLine();
                        
                        if (tabla == "1")
                        {
                            try
                            {
                                var customer = cl.GetById(id);
                                Console.WriteLine($"\t {customer.CustomerID} - {customer.ContactName} trabaja en {customer.CompanyName} y vive en {customer.City}, {customer.Country}.");
                            }
                            catch (BadIDException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Los IDs de esta tabla son strings de 5 caracteres.");
                            }
                        }
                        else
                        {
                            try
                            {
                                var employee = el.GetById(id);
                                Console.WriteLine($"\t {employee.EmployeeID} - {employee.FirstName} {employee.LastName} vive en {employee.City}, {employee.Country}.");
                            }
                            catch (BadIDException e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Los IDs de esta tabla son numeros enteros.");
                            }
                        }

                        continue;
                    }
                }
            }

            Console.ReadKey();
        }
    }
}
