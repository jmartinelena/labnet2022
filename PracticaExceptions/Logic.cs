using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaExceptions.Exceptions;

namespace PracticaExceptions
{
    public class Logic
    {
        public void LanzarExcepcion()
        {
            throw new Exception();
        }

        public void LanzarExcepcionPersonalizada()
        {
            throw new ExcepcionPersonalizada();
        }
    }
}
