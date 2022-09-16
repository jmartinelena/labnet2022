using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    public abstract class TransportePublico
    {
        private int _pasajeros = 0;


        public TransportePublico(int pasajeros)
        {
            _pasajeros = pasajeros;
        }


        public int Pasajeros { get { return _pasajeros; } }

        public abstract void Avanzar();

        public abstract void Detenerse();
    }
}
