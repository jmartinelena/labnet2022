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

            List<Customers> customers = cl.GetAll();

            foreach(Customers customer in customers)
            {
                if (customer.Country.ToLower() == "argentina")
                {
                    Console.WriteLine($"{customer.ContactName} works at {customer.CompanyName} and lives in {customer.City}, {customer.Country}.");
                }
            }

            Console.ReadKey();
        }
    }
}
