using Practica.LINQ.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practica.LINQ.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Queries q = new Queries();

            Console.WriteLine("----------------------- 1 -----------------------");

            Console.WriteLine(q.Query1());

            Console.WriteLine("----------------------- 2 -----------------------");

            foreach (var item in q.Query2())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------- 3 -----------------------");

            foreach (var item in q.Query3())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------- 4 ----------------------");

            foreach (var item in q.Query4())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------- 5 ---------------------");

            Console.WriteLine(q.Query5());

            Console.WriteLine("----------------------- 6 ---------------------");

            foreach (var item in q.Query6())
            {
                Console.WriteLine($"Minusculas: {item.ToLower()} - Mayusculas: {item.ToUpper()}");
            }

            Console.WriteLine("----------------------- 7 ----------------------");

            foreach (var item in q.Query7())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------- 8 ----------------------");

            foreach (var item in q.Query8())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------- 9 ---------------------");

            foreach (var item in q.Query9())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------- 10 ---------------------");

            foreach (var item in q.Query10())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------- 11 ---------------------");

            foreach (var item in q.Query11())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("----------------------- 12 ---------------------");

            Console.WriteLine(q.Query12(q.Query10()));

            Console.WriteLine("----------------------- 13 ---------------------");

            foreach (var item in q.Query13())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------------------------------");
            
            Console.ReadLine();
        }
    }
}
