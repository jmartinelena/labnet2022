using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    public class Omnibus : TransportePublico
    {
        public Omnibus(int pasajeros) : base(pasajeros)
        {
        }

        public static int MaxPasajeros { get { return 30; } }

        public override void Avanzar()
        {
            Console.WriteLine("Soy un omnibus y estoy avanzando. Si es hora pico e intentas pararme te paso de largo.");
        }

        public override void Detenerse()
        {
            Console.WriteLine("Soy un omnibus y me detuve.");
        }
    }
}
