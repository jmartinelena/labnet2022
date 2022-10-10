using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica.MVC.API.Models
{
    public class EmployeeRequest
    {
        [RegularExpression("^[0-9]+$")]
        public string Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 1)]
        public string LastName { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 1)]
        public string FirstName { get; set; }
    }
}