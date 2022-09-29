using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.LINQ
{
    public static class QueryReader
    {
        public static void ShowQuery<T>(IQueryable<T> query, int excerciseNumber )
        {
            Console.WriteLine($"----------------------- {excerciseNumber} -----------------------");

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        public static void ShowQuery<T>(List<T> query, int excerciseNumber)
        {
            Console.WriteLine($"----------------------- {excerciseNumber} -----------------------");

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}
