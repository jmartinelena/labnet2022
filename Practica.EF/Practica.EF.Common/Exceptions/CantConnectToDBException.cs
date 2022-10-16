using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Common.Exceptions
{
    public class CantConnectToDBException : Exception
    {
        public CantConnectToDBException() : base("Se rompio la conexion con la base de datos.")
        {

        }
    }
}
