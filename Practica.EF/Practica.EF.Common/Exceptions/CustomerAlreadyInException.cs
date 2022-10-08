using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.MVC.Common.Exceptions
{
    public class CustomerAlreadyInException : Exception
    {
        public CustomerAlreadyInException(string id) : base($"No se puede agregar el customer ya que el id {id.ToUpper()} ya se encuentra en la base.")
        {

        }
    }
}
