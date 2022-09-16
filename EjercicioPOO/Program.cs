using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Esto podria reemplazarlo por metodos estaticos Taxi.LlenarN(5) (analogo para micros), pero no me lo piden.
            Taxi[] taxis = new Taxi[5];
            Omnibus[] omnibuses = new Omnibus[5];

            Console.Write("Llenando ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("taxis\n");
            Console.ForegroundColor = ConsoleColor.White;

            for(int i = 0; i < taxis.Length; i++)
            {
                Console.Write("Llenando el ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{i+1}-esimo ");
                Console.ForegroundColor= ConsoleColor.White;
                Console.Write("taxi: ");
                int pasajeros;
                while (true)
                {
                    Console.Write("\n\tCuantos pasajeros (como numero entero entre 0 y 5) tiene este taxi? ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string input = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    // Considero que un taxi puede estar vacio
                    if (int.TryParse(input, out pasajeros) && pasajeros <= Taxi.MaxPasajeros && pasajeros >= 0)
                    {
                        taxis[i] = new Taxi(pasajeros);
                        break;
                    } else
                    {
                        Console.Write("\tValor invalido de pasajeros, ingrese un valor valido entre 0 y 5.");
                    }
                }
            }
            Console.WriteLine();


            for (int i=0; i < taxis.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Taxi ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{i + 1}: {taxis[i].Pasajeros} pasajeros.\n");
            }
            Console.WriteLine("---------------------------------------------");


            Console.Write("Llenando ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("omnibuses\n");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < omnibuses.Length; i++)
            {
                Console.Write("Llenando el ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{i + 1}-esimo ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("omnibus: ");
                int pasajeros;
                while (true)
                {
                    Console.Write("\n\tCuantos pasajeros (como numero entero entre 0 y 30) tiene este omnibus? ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    string input = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    // Considero que un omnibus puede estar vacio
                    if (int.TryParse(input, out pasajeros) && pasajeros <= Omnibus.MaxPasajeros && pasajeros >= 0)
                    {
                        omnibuses[i] = new Omnibus(pasajeros);
                        break;
                    }
                    else
                    {
                        Console.Write("\tValor invalido de pasajeros, ingrese un valor valido entre 0 y 30.");
                    }
                }
            }
            Console.WriteLine();


            for (int i = 0; i < omnibuses.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Omnibus ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{i + 1}: {omnibuses[i].Pasajeros} pasajeros.\n");
            }


            Console.ReadKey();
        }
    }
}
