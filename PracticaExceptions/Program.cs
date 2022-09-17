using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaExceptions.Exceptions;

namespace PracticaExceptions
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Practica de Exceptions, Extension Methods y Unit Tests.";
            Console.WriteLine("Elija una opcion entre las siguientes: ");
            for (int i = 1; i < 5; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\t{i}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" - Corre el inciso {i}.\n");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\tSalir");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" - Rompe el bucle.\n\n");

            while (true)
            {
                Console.Write("Escriba el comando correspondiente a la operacion que desea a continuacion: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (input == "1")
                {
                    Calculadora.DividirPorCero();
                }
                else if (input == "2")
                {
                    Calculadora.Dividir();
                }
                else if (input == "3")
                {
                    Logic logic = new Logic();
                    try
                    {
                        logic.LanzarExcepcion();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Mensaje de la excepcion: {ex.Message}");
                        Console.WriteLine($"Tipo de la excepcion: {ex.GetType().Name}");
                    }
                }
                else if (input == "4")
                {
                    Logic logic = new Logic();
                    try
                    {
                        logic.LanzarExcepcionPersonalizada();
                    }
                    catch (ExcepcionPersonalizada ex)
                    {
                        Console.WriteLine($"Mensaje de la excepcion: {ex.Message}");
                        Console.WriteLine($"Tipo de la excepcion: {ex.GetType().Name}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Algo salio mal.");
                        Console.WriteLine($"Mensaje de la excepcion: {ex.Message}");
                        Console.WriteLine($"Tipo de la excepcion: {ex.GetType().Name}");
                    }
                }
                else if (input.ToLower() == "salir")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Comando invalido. Por favor intente de nuevo.");
                }
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------");
                Console.ResetColor();
            }
            
            Console.ReadKey();
        }
    }
}
