using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExceptions
{
    public class Calculadora
    {
        public static void DividirPorCero()
        {
            bool exito = true;
            Console.Write("Ingrese un valor a dividir por cero: ");
            try
            {
                int value = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("El resultado es: " + value / 0);
            }
            catch (DivideByZeroException ex)
            {
                exito = false;
                Console.WriteLine("Se intento dividir por cero.");
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Seguro ingreso un valor invalido o no ingreso nada.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Alguna otra cosa salio mal.");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                string mensaje = exito ? "Se realizo la operacion con exito." : "La operacion fallo.";
                Console.WriteLine(mensaje);
            }
        }

        public static void Dividir()
        {
            try
            {
                Console.Write("Ingrese un valor para el dividendo: ");
                int dividendo = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ingrese un valor para el divisor: ");
                int divisor = Convert.ToInt32(Console.ReadLine());
                double resultado = (float)dividendo / divisor;
                if (divisor == 0) throw new DivideByZeroException();
                Console.WriteLine("El resultado es: " + resultado);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Lisa, en esta casa nosotros obedecemos las reglas del analisis matematico.");
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Seguro ingreso un valor invalido o no ingreso nada.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Alguna otra cosa salio mal.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
