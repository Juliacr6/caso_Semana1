using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_Semana1
{
    internal class validador
    {
        public static int leerEnteros(string mensaje)
        {
            int valor;
            while (true)
            {
                Console.Write(mensaje);
                if (int.TryParse(Console.ReadLine(),out valor))
                {
                    if(valor<1 || valor >5)
                    {
                        Console.WriteLine("Erro: fuer de rango(1-5)");
                        continue;
                    }
                    return valor;
                }
                Console.WriteLine("Error:ingresar un valor numerico entero");
            }
        }
        public static double LeerDecimal(string mensaje)
        {
            double valor;
            while(true)
            {
                Console.Write(mensaje);
                if(double.TryParse(Console.ReadLine(), out valor))
                {
                    if (valor < 0 || valor > 20)
                    {
                        Console.WriteLine("Error:las notas deben ser entre 0-20");
                        continue;
                    }
                    return valor;
                }
                Console.WriteLine("Error: el valor debe ser numerico decimal");
            }
        }
        public static string LeerTexto(string mensaje)
        {
            while(true)
            {
                Console.Write(mensaje);
                string valor = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(valor))
                    return valor;
                Console.WriteLine("Error: este campo no puede estar vacío");
            }
        }
    }
}
