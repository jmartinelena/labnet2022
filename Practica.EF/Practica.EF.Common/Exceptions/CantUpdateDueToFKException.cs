using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.MVC.Common.Exceptions
{
    public class CantUpdateDueToFKException : Exception
    {
        // No tengo ni idea por que pasa esto
        public CantUpdateDueToFKException(string id) : base($"Se intento eliminar la entidad con id {id} y despues actualizarla. No se pudo eliminar por estar relacionada a otras tablas a traves de FKs, esto genero un error e impidio que se puedan actualizar los valores de la tabla EN GENERAL.\nLas actualizaciones que haga a partir de ahora en en esta tabla no se guardaran en la base de datos.\nNo se por que pasa esto, pero para poder actualizar los valores de la tabla, reinicie la aplicacion e intente de nuevo sin intentar antes borrar el registro.")
        {

        }
    }
}
