using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Departamento
    {
        public static void Add()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Por favor ingrese la sigiuente información");
            Console.Write("Nombre de departamento: ");
            departamento.Nombre = Console.ReadLine();

            Console.Write("Ingrese el área del departamento: ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Departamento.Add(departamento);
            //ML.Result result = BL.Departamento.AddSP(departamento);


            //ML.Result result = BL.Departamento.AddEF(departamento);

            ML.Result result = BL.Departamento.AddLINQ(departamento);

            if(result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }
        }

        public static void GetAll()
        {


            //ML.Result result = BL.Departamento.GetAll();

            //ML.Result result = BL.Departamento.GetAllEF();
            ML.Result result = BL.Departamento.GetAllLINQ();
            
            if(result.Correct)
            {
                foreach(ML.Departamento departamento in result.Objects)
                {

                    Console.WriteLine("El id de departamento es: " + departamento.IdDepartamento);
                    Console.WriteLine("El nombre del departamento es: " + departamento.Nombre);
                    Console.WriteLine("El area del departamentos es: " + departamento.Area.IdArea);
                    Console.WriteLine("---------------------------------------------------\n");
                }
            }
        }
        public static void GetById()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.Write("Ingrese el id del departamento a consultar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());


            //ML.Result result = BL.Departamento.GetById(departamento.IdDepartamento);

            //ML.Result result = BL.Departamento.GetByIdEF(departamento.IdDepartamento);

            ML.Result result = BL.Departamento.GetByIdLINQ(departamento.IdDepartamento);

            if(result.Correct)
            {
                departamento = (ML.Departamento)result.Object;
                Console.WriteLine("El id de departamento es: " + departamento.IdDepartamento);
                Console.WriteLine("El nombre del departamento es: " + departamento.Nombre);
                Console.WriteLine("El area del departamentos es: " + departamento.Area.IdArea);
                Console.WriteLine("---------------------------------------------------\n");
            }


        }

        public static void Update()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.Write("Ingrese el id del departamento a modificar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Por favor ingrese la siguiente información a modificar");
            Console.Write("Nombre del departamento: ");
            departamento.Nombre = Console.ReadLine();

            departamento.Area = new ML.Area();
            Console.Write("Ingrese el área del departamento: ");
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Departamento.UpdateSP(departamento);

            //ML.Result result = BL.Departamento.UpdateEF(departamento);
            ML.Result result = BL.Departamento.UpdateLINQ(departamento);

            if(result.Correct)
            {
                Console.WriteLine("Mensaje " + result.Message);
            }

        }

        public static void Delete()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.Write("Ingrese el id del departamento a eliminar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Departamento.Delete(departamento.IdDepartamento);

            //ML.Result result = BL.Departamento.DeleteEF(departamento.IdDepartamento);
            ML.Result result = BL.Departamento.DeleteLINQ(departamento.IdDepartamento);

            if(result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }
        }
    }
}
