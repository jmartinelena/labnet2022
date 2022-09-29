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

            QueryReader.ShowQuery(q.Query2(), 2);

            QueryReader.ShowQuery(q.Query3(), 3);

            QueryReader.ShowQuery(q.Query4(), 4);

            Console.WriteLine("----------------------- 5 ---------------------");

            Console.WriteLine(q.Query5());

            Console.WriteLine("----------------------- 6 ---------------------");

            foreach (var item in q.Query6())
            {
                Console.WriteLine($"Minusculas: {item.ToLower()} - Mayusculas: {item.ToUpper()}");
            }

            QueryReader.ShowQuery(q.Query7(), 7);

            QueryReader.ShowQuery(q.Query8(),8);

            QueryReader.ShowQuery(q.Query9(), 9);

            QueryReader.ShowQuery(q.Query10(), 10);

            QueryReader.ShowQuery(q.Query11(), 11);

            Console.WriteLine("----------------------- 12 ---------------------");

            Console.WriteLine(q.Query12(q.Query10()));

            QueryReader.ShowQuery(q.Query13(),13);

            Console.WriteLine("-----------------------------------------------");
            
            Console.ReadLine();
        }
    }
}
