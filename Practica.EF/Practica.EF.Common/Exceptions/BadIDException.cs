﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica.EF.Common.Exceptions
{
    public class BadIDException : Exception
    {
        public BadIDException(int id) : base($"El id {id} no existe, no es valido o no es unico.")
        {

        }
    }
}
