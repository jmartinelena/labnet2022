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
    public class CustomerOperations
    {
        private readonly ILogic<Customers> _cl = new CustomerLogic();

        public void GetAll()
        {
            foreach (var customer in _cl.GetAll())
            {
                Console.WriteLine($"\t {customer}");
            }
        }

        public void GetByCountry(string country)
        {
            try
            {
                foreach (var customer in _cl.GetByCountry(country))
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

        public void GetById(string id)
        {
            try
            {
                var customer = _cl.GetById(id);
                Console.WriteLine($"\t {customer}");
            }
            catch (BadIDException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine("Los IDs de esta tabla son strings de 5 caracteres.");
            }
        }

        public void Add(string customerId, string companyName)
        {
            try
            {
                _cl.Add(new Customers() { CustomerID = customerId, CompanyName = companyName });
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

        public void Update(string customerId, string companyName)
        {
            try
            {
                _cl.Update(new Customers() { CustomerID = customerId, CompanyName = companyName });
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

        public void Delete(string customerId)
        {
            try
            {
                _cl.Delete(customerId);
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
    }
}
