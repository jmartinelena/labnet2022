using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.MVC.Common.Exceptions
{
    public class InvalidEmployeeException : Exception
    {
        public InvalidEmployeeException() : base("Se ha ingresado un employee inválido. Verificar los tipos y restricciones usados a la hora de definirlo.")
        {

        }
    }
}
