using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.MVC.Common.Exceptions
{
    public class BadCountryException : Exception
    {
        public BadCountryException(string country) : base($"No reconozco '{country}' como pais valido o no existe.")
        {

        }
    }
}
