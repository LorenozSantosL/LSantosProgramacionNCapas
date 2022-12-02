using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Agregar un registro presione: 1\n"
                + "Modificar un registro presione: 2\n" +
                 "Eliminar un registro presione: 3\n" +
                 "Para obtener todos los registros presione 4\n" +
                 "Para obtener un registro presione: 5\n" +
                 "-------------------------------------------------------------\n" +
                 "Para agregar un departamento presione: 6\n" +
                 "Para obtener todos los datos de departamento presione: 7\n" +
                 "Para obtener solo un registro de departamento presione: 8\n"+
                 "Para modificar un departamento presione: 9\n"+
                 "Para eliminar un departamento presion: 10\n"
                 );
            Console.Write("Seleccione una opcion: ");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Usuario.Add();
                    break;
                case 2:
                    Usuario.Update();
                    break;
                case 3:
                    Usuario.Delete();
                    break;
                case 4:
                    Usuario.GetAll();
                    break;
                case 5:
                    Usuario.GetById();
                    break;
                case 6:
                    Departamento.Add();
                    break;
                case 7:
                    Departamento.GetAll();
                    break;
                case 8:
                    Departamento.GetById();
                    break;
                case 9:
                    Departamento.Update();
                    break;
                case 10:
                    Departamento.Delete();
                    break;
                default:
                    Console.WriteLine("Opción incorrecta");
                    break;
            }
        }
    }
}
