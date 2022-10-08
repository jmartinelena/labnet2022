using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.MVC.Common.Exceptions
{
    public class BadIDException : Exception
    {
        public BadIDException(string id) : base($"El id {id} no existe, no es valido o no es unico.")
        {

        }
    }
}
