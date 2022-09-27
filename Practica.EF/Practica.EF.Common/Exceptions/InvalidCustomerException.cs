using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Common.Exceptions
{
    public class InvalidCustomerException :Exception
    {
        public InvalidCustomerException() : base("Se ha ingresado un customer invalido. Verificar los tipos y restricciones usados a la hora de definirlo.")
        {

        }
    }
}
