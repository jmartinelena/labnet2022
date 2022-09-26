using Practica.EF.Common.Exceptions;
using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public class EmployeeLogic : BaseLogic, ILogic<Employees>
    {
        public List<Employees> GetAll()
        {
            return _context.Employees.ToList();
        }

        public List<Employees> GetByCountry(string country)
        {
            if (_context.Employees.Any(e => e.Country.ToLower() == country.ToLower()))
            {
                //return _context.Employees.Where(e => e.Country == country).ToList();
                var employeesByCountry = from e in _context.Employees where e.Country == country select e;
                return employeesByCountry.ToList();
            }
            else
            {
                throw new BadCountryException(country);
            }
        }

        public Employees GetById(string id)
        {
            try
            {
                int idAsInt = int.Parse(id);
                return _context.Employees.Single(e => e.EmployeeID == idAsInt);
            }
            catch (InvalidOperationException)
            {
                throw new BadIDException(id);
            }
            catch(FormatException)
            {
                throw new BadIDException(id);
            }
        }
    }
}
