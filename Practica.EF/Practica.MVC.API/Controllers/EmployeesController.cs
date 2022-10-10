using Practica.MVC.API.Models;
using Practica.MVC.Common.Exceptions;
using Practica.MVC.Entities;
using Practica.MVC.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace Practica.MVC.API.Controllers
{
    public class EmployeesController : ApiController
    {
        private readonly EmployeeLogic _el = new EmployeeLogic();

        // GET api/Employees
        public IHttpActionResult GetEmployees()
        {
            try
            {
                List<Employees> employees = _el.GetAll();

                List<EmployeeResponse> listaEmployees = employees
                    .Select(e => new EmployeeResponse() {
                        Id = Convert.ToString(e.EmployeeID), LastName = e.LastName, FirstName = e.FirstName
                    })
                    .ToList();

                return Ok(listaEmployees);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, new { Error = ex.Message });
            }
        }

        // GET api/Employees/{id}
        public IHttpActionResult GetEmployeeById(string id)
        {
            try
            {
                Employees employee = _el.GetById(id);
                
                EmployeeResponse employeeModel = new EmployeeResponse()
                {
                    Id = Convert.ToString(employee.EmployeeID),
                    LastName = employee.LastName,
                    FirstName = employee.FirstName
                };
                
                return Ok(employeeModel);
            }
            catch (BadIDException ex)
            {

                return Content(HttpStatusCode.NotFound, new { Error = ex.Message });
            }
        }

        // POST api/Employees
        public IHttpActionResult AddEmployee([FromBody] EmployeeRequest employee)
        {
            try
            {
                // No es necesario mandarle un ID porque en la BD es autoincremental y no le importa que ID le pase, la asigna sola
                Employees emp = new Employees()
                {
                    LastName = employee.LastName,
                    FirstName = employee.FirstName
                };

                _el.Add(emp);

                // Hago esto porque si mostrara employee en vez del objeto anonimo mostraria id como null, lo cual se presta
                // a confusion, ya que en realidad si se le asigna un id, pero se le asigna automatico y no manual al tener
                // la BD el campo id como autoincremental
                return Content(HttpStatusCode.Created, new { LastName = employee.LastName, FirstName = employee.FirstName });
            }
            catch (InvalidEmployeeException ex)
            {
                return Content(HttpStatusCode.Conflict, new { Error = ex.Message });
            }
            catch (EmployeeAlreadyInException ex)
            {
                return Content(HttpStatusCode.Conflict, new { Error = ex.Message });
            }
        }

        // PUT api/Employees/{id}
        [HttpPut] // Si no lo explicito asi lo reconoce como POST en vez de PUT
        public IHttpActionResult UpdateEmployee(int id, [FromBody] EmployeeRequest employee)
        {
            try
            {
                if (!int.TryParse(employee.Id, out int idAsInt) || idAsInt != id) throw new BadIDException(employee.Id);

                Employees emp = new Employees()
                {
                    EmployeeID = id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName
                };

                _el.Update(emp);
                return Content(HttpStatusCode.OK, employee);
            }
            catch (InvalidEmployeeException ex)
            {
                return Content(HttpStatusCode.Conflict, new { Error = ex.Message });
            }
            catch (BadIDException ex)
            {
                return Content(HttpStatusCode.Conflict, new { Error = ex.Message });
            }
            catch (CantUpdateDueToFKException ex)
            {
                return Content(HttpStatusCode.Conflict, new { Error = ex.Message });
            }
        }

        // DELETE api/Employees/{id}
        public IHttpActionResult DeleteEmployee(int id)
        {
            try
            {
                _el.Delete(Convert.ToString(id));
                return Ok();
            }
            catch (BadIDException ex)
            {
                return Content(HttpStatusCode.Conflict, new { Error = ex.Message });
            }
            catch (CantDeleteDueToFKException ex)
            {
                return Content(HttpStatusCode.Conflict, new { Error = ex.Message });
            }
        }
    }
}