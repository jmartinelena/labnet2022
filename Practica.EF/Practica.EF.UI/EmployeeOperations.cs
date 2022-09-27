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
    public class EmployeeOperations
    {
        private readonly ILogic<Employees> _el = new EmployeeLogic();

        public void GetAll()
        {
            foreach (var employee in _el.GetAll())
            {
                Console.WriteLine($"\t {employee}");
            }
        }

        public void GetByCountry(string country)
        {
            try
            {
                foreach (var employee in _el.GetByCountry(country))
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

        public void GetById(string id)
        {
            try
            {
                var employee = _el.GetById(id);
                Console.WriteLine($"\t {employee}");
            }
            catch (BadIDException e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine("Los IDs de esta tabla son numeros enteros.");
            }
        }

        // No pongo el id porque es autoincremental y a la BD no le importa cual le pase
        public void Add(string lastName, string firstName)
        {
            try
            {
                _el.Add(new Employees() { LastName = lastName, FirstName = firstName });
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

        public void Update(string employeeId, string lastName, string firstName)
        {
            try
            {
                if (!int.TryParse(employeeId, out _)) throw new InvalidEmployeeException();
                _el.Update(new Employees() { EmployeeID = int.Parse(employeeId), LastName = lastName, FirstName = firstName });
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

        public void Delete(string employeeId)
        {
            try
            {
                if (!int.TryParse(employeeId, out _)) throw new BadIDException(employeeId);
                _el.Delete(employeeId);
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
