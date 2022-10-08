using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.MVC.Common.Exceptions
{
    public class CantDeleteDueToFKException : Exception
    {
        public CantDeleteDueToFKException(string id) : base($"El id {id} no puede eliminarse porque esta relacionado con otra/s tabla/s a traves de foreign key/s.")
        {

        }
    }
}
