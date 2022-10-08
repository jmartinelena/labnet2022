using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Practica.MVC.MVC.Models
{
    public class ErrorView
    {
        [Required]
        public string Message { get; set; }
    }
}