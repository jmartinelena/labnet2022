using Microsoft.Ajax.Utilities;
using Practica.MVC.Common.Exceptions;
using Practica.MVC.Entities;
using Practica.MVC.Logic;
using Practica.MVC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica.MVC.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeLogic el = new EmployeeLogic();
        
        // GET: Employee
        public ActionResult Index()
        {
            List<Employees> employees = el.GetAll();

            List<EmployeeView> employeeViews = employees
                .Select(e => new EmployeeView() { Id = e.EmployeeID, LastName = e.LastName, FirstName = e.FirstName })
                .ToList();

            return View(employeeViews);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(EmployeeView employeeView)
        {
            try
            {
                Employees employeeEntity = new Employees() { LastName = employeeView.LastName, FirstName = employeeView.FirstName };
                el.Add(employeeEntity);
                return RedirectToAction("Index");
            }
            catch (InvalidEmployeeException ex)
            {
                return RedirectToAction("Index", "Error", new ErrorView() { Message = ex.Message});
            }
            catch (EmployeeAlreadyInException ex)
            {
                return RedirectToAction("Index", "Error", new ErrorView() { Message = ex.Message });
            }
        }

        public ActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(EmployeeView employeeView)
        {
            try
            {
                Employees updatedEmployee = new Employees() {
                    EmployeeID = employeeView.Id, 
                    LastName = employeeView.LastName, 
                    FirstName = employeeView.FirstName };

                el.Update(updatedEmployee);
                return RedirectToAction("Index");
            }
            catch (InvalidEmployeeException ex)
            {
                return RedirectToAction("Index", "Error", new ErrorView() { Message = ex.Message });
            }
            catch (BadIDException ex)
            {
                return RedirectToAction("Index", "Error", new ErrorView() { Message = ex.Message });
            }
            catch (CantUpdateDueToFKException ex)
            {
                return RedirectToAction("Index", "Error", new ErrorView() { Message = ex.Message });
            }
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(EmployeeView ev)
        {
            try
            {
                string id = Convert.ToString(ev.Id);
                el.Delete(id);
                return RedirectToAction("Index");
            }
            catch (BadIDException ex)
            {
                return RedirectToAction("Index", "Error", new ErrorView() { Message = ex.Message });
            }
            catch (CantDeleteDueToFKException ex)
            {
                return RedirectToAction("Index", "Error", new ErrorView() { Message = ex.Message });
            }
        }
    }
}