using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExceptions.Exceptions
{
    public class ExcepcionPersonalizada : Exception
    {
        public ExcepcionPersonalizada() : base("Mensaje de error personalizado.")
        {

        }
    }
}
