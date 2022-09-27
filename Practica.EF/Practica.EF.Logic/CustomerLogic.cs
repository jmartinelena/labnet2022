using Practica.EF.Common.Exceptions;
using Practica.EF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Logic
{
    public class CustomerLogic : BaseLogic<Customers>
    {

        public override List<Customers> GetAll()
        {
            return _context.Customers.ToList();
        }

        public override List<Customers> GetByCountry(string country)
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

        public override Customers GetById(string id)
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
        
        public override void Add(Customers newCustomer)
        {
            try
            {
                _context.Customers.Add(newCustomer);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                throw new InvalidCustomerException();
            }
            catch (DbUpdateException)
            {
                throw new CustomerAlreadyInException(newCustomer.CustomerID);
            }
        }

        public override void Delete(string id)
        {
            try
            {
                var customerAEliminar = _context.Customers.Single(c => c.CustomerID == id);
                _context.Customers.Remove(customerAEliminar);
                _context.SaveChanges();
            }
            catch (InvalidOperationException)
            {
                throw new BadIDException(id);
            }
            catch (DbUpdateException)
            {
                throw new CantDeleteDueToFKException(id);
            }
        }

        // Esto mas bien reemplaza una una fila por otra
        public override void Update(Customers newCustomer)
        {
            try
            {
                var customerAUpdatear = _context.Customers.Single(c => c.CustomerID == newCustomer.CustomerID);

                if (newCustomer.CompanyName != null && newCustomer.CompanyName.Length >=1 && newCustomer.CompanyName.Length <= 40)
                {
                    customerAUpdatear.CompanyName = newCustomer.CompanyName;
                }
                else
                {
                    throw new InvalidCustomerException();
                }

                // Fuerza al state de la entidad a ser modificado en caso que haya quedado marcado para borrar anteriormente
                _context.Entry(customerAUpdatear).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                throw new InvalidCustomerException();
            }
            catch (InvalidOperationException)
            {
                throw new BadIDException(newCustomer.CustomerID);
            }
            //catch (DbUpdateException)
            //{
            //    throw new CantUpdateDueToFKException(newCustomer.CustomerID);
            //}
        }
    }
}
