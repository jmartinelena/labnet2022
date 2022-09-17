using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExceptions
{
    public static class RandomExtensions
    {
        // El nombre del metodo esta en ingles porque la clase Random tiene sus metodos en ingles, no me peguen.
        public static bool CoinFlip(this Random random)
        {
            return random.Next(2) == 1; // devuelve true o false con un 50% de chances para cada posibilidad.
        }
    }
}
