using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caso_Semana1
{
    internal class Program
    {
        static int max_estudiantes = 40;
        static int max_cursos = 4;
        static string[] nombre_de_cursos = { "Matemáticas", "Programacion", "Base de datos", "Física" };
        static string[] estudiantes = new string[max_estudiantes];
        static double[,] matrizNotas = new double[max_estudiantes, max_cursos];
        static int total_estudiantes = 0;
        static string rutaArchivo = "notas_cursos.txt";
        public static void RegitrarEstudiantes()
        {
            Console.WriteLine("Registro de estudiantes");
            if(total_estudiantes>=max_estudiantes)
            {
                Console.WriteLine("Capacidad máximo de estudiantes alcanzada");
                return;
            }
            string nombre = validador.LeerTexto("Ingresar nombres y Apellidos").ToUpper();
            estudiantes[total_estudiantes] = nombre;
            Console.WriteLine("Ingresar notas para cada curso(0-20)");
            for(int i=0;1<max_cursos;i++)
            {
                matrizNotas[total_estudiantes, i] = validador.LeerDecimal($"-{nombre_de_cursos[i]}:");
            }
            total_estudiantes++;
            Console.WriteLine("Estudiante registro...!");
        }
        public static void GuardarArchivo()
        {
            if (total_estudiantes == 0)
            {
                Console.WriteLine("No hay registro por guardar");
                return;
            }
            using (StreamWriter escribir = new StreamWriter(rutaArchivo))
            {
                for (int i = 0; i < total_estudiantes; i++)
                {
                    string linea = estudiantes[i];
                    for (int j = 0; j < max_cursos; j++)
                    {
                        linea += $",{matrizNotas[i, j]}";
                        //linea +=","+matriznotas[i,j]
                    }
                    escribir.WriteLine(linea);
                }
            }
            Console.WriteLine("Registros guardados");
        }
        public static void CargarRegistros()
        {
            Console.WriteLine("Cargar registros desde archivo");
            if (!File.Exists(rutaArchivo))
            {
                Console.WriteLine("No encontró archivo...");
                return;
            }
            total_estudiantes = 0;
            using (StreamReader lector = new StreamReader(rutaArchivo))
            {
                string linea;
                while((linea=lector.ReadLine())!=null && total_estudiantes<max_estudiantes)
                {
                    string[] partes = linea.Split(',');
                    if(partes.Length==max_cursos+1)
                    {
                        estudiantes[total_estudiantes] = partes[0];
                        for (int i = 0; i < max_cursos; i++)
                        {
                            matrizNotas[total_estudiantes, i] = Convert.ToDouble(partes[i + 1]);
                        }
                        total_estudiantes++;
                    }
                }

            }
            Console.WriteLine("Se cargaron" + total_estudiantes + "con sus notas");
        }
        public static void mostrarRgistros()
        {
            Console.WriteLine(new string('=', 100));
            Console.WriteLine("\t\tREPORTE GENERAL DE NOTAS POR CURSO");
            Console.WriteLine(new string('=', 100));
            if(total_estudiantes==0)
            {
                Console.WriteLine("No hay registros");
               return;
            }
            Console.Write($"{"ESTUDIANTE",-25}");
            for(int i=0; i<max_cursos; i++)
            {
                Console.Write($"{nombre_de_cursos[i],-12}|");
            }
            Console.WriteLine("PROMEDIO");
            Console.WriteLine(new string('-',100));
            for (int i = 0; i < total_estudiantes; i++) 
            {
                Console.Write($"{estudiantes[i],-25}|");
                double suma = 0;
                for (int j = 0; j < max_cursos; j++) 
                {
                    Console.Write($"{matrizNotas[i,j],-12:F1}|");
                    suma += matrizNotas[i, j];
                }
                double promedio = suma / max_cursos;
                string estado = promedio >= 12 ? "APROBADO" : "DESAPROBADO";
                Console.WriteLine($"{promedio:F2}({estado}");
            }

        }  
        static void Main(string[] args)
        {
            int opc = 0;
            while(opc!=5)
            {
                Console.Clear();
                Console.WriteLine("[1]Registrar estudiante");
                Console.WriteLine("[2]Guardar en Archivo");
                Console.WriteLine("[3]Cargar el Archivo");
                Console.WriteLine("[4]Mostrar los Registros");
                Console.WriteLine("[5]Salir");
                opc = validador.leerEnteros("Seleccione la opción[1-5]:");
                switch(opc)
                {
                    case 1:
                        RegitrarEstudiantes();
                        break;
                    case 2:
                        GuardarArchivo();
                        break;
                    case 3:
                        CargarRegistros();
                        break;
                    case 4:
                        mostrarRgistros();
                        break;
                    case 5:
                        Console.WriteLine("Muchos éxitos para tu examen final");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
