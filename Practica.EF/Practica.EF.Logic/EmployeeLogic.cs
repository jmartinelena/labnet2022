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
    public class EmployeeLogic : BaseLogic<Employees>
    {
        public override List<Employees> GetAll()
        {
            return _context.Employees.ToList();
        }

        public override List<Employees> GetByCountry(string country)
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

        public override Employees GetById(string id)
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

        public override void Add(Employees newEmployee)
        {
            try
            {
                _context.Employees.Add(newEmployee);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                throw new InvalidEmployeeException();
            }
            catch (DbUpdateException)
            {
                throw new EmployeeAlreadyInException(newEmployee.EmployeeID);
            }
        }

        public override void Delete(string id)
        {
            try
            {
                int idAsInt = int.Parse(id);
                var employeeAEliminar = _context.Employees.Single(e => e.EmployeeID == idAsInt);
                _context.Employees.Remove(employeeAEliminar);
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
            catch (FormatException)
            {
                throw new BadIDException(id);
            };
        }

        public override void Update(Employees newEmployee)
        {
            try
            {
                var employeeAUpdatear = _context.Employees.Single(e => e.EmployeeID == newEmployee.EmployeeID);

                if (newEmployee.LastName == null || newEmployee.FirstName == null)
                {
                    throw new InvalidEmployeeException();
                }
                
                employeeAUpdatear.LastName = newEmployee.LastName;
                employeeAUpdatear.FirstName = newEmployee.FirstName;

                // Fuerza al state de la entidad a ser modificado en caso que haya quedado marcado para borrar anteriormente
                _context.Entry(employeeAUpdatear).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                throw new InvalidEmployeeException();
            }
            catch (InvalidOperationException)
            {
                throw new BadIDException(Convert.ToString(newEmployee.EmployeeID));
            }
            //catch (DbUpdateException)
            //{
            //    throw new CantUpdateDueToFKException(Convert.ToString(newEmployee.EmployeeID));
            //}
        }
    }
}
