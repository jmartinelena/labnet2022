using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Common.Exceptions
{
    public class EmployeeAlreadyInException : Exception
    {
        public EmployeeAlreadyInException(int id) : base($"No se puede agregar el customer ya que el id {id} ya se encuentra en la base.")
        {

        }
    }
}
