using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica.MVC.MVC.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20,MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10,MinimumLength = 1)]
        public string FirstName { get; set; }
    }
}