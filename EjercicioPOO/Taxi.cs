using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPOO
{
    public class Taxi : TransportePublico
    {
        public Taxi(int pasajeros) : base(pasajeros)
        {
        }

        public static int MaxPasajeros { get { return 5; } }

        public override void Avanzar()
        {
            Console.WriteLine("Soy un taxi y estoy avanzando.");
        }

        public override void Detenerse()
        {
            Console.WriteLine("Soy un taxi y me detuve.");
        }
    }
}
