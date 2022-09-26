using Practica.EF.Common.Exceptions;
using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public class CustomerLogic : BaseLogic, ILogic<Customers>
    {
        public List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }

        public List<Customers> GetByCountry(string country)
        {
            if (_context.Customers.Any(c => c.Country.ToLower() == country.ToLower()))
            {
                //return _context.Customers.Where(c => c.Country == country).ToList();
                var customersByCountry = from c in _context.Customers where c.Country == country select c;
                return customersByCountry.ToList();
            }
            else
            {
                throw new BadCountryException(country);
            }
        }

        public Customers GetById(string id)
        {
            try
            {
                return _context.Customers.Single(c => c.CustomerID == id.ToUpper());
            }
            catch (InvalidOperationException)
            {
                throw new BadIDException(id);
            }
        }
    }
}
