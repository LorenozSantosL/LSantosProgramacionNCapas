using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuario
    {
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Por favor ingresar la infomacion a modificar");
            Console.Write("Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.Write("Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.Write("Fecha de nacimiento (dd-MM-yyyy): ");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.Write("Genero (M: Masculino, F: Fememino): ");
            usuario.Sexo = Console.ReadLine();
            Console.Write("Ingrese su Email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese su nombre de usuario: ");
            usuario.UserName = Console.ReadLine();
            Console.Write("Ingrese su contraseña: ");
            usuario.Password = Console.ReadLine();
            Console.Write("Ingrese su número de telefono: ");
            usuario.Telefono = Console.ReadLine();
            Console.Write("Ingrese su número de celular: ");
            usuario.Celular = Console.ReadLine();
            Console.Write("Ingrese su CURP: ");
            usuario.CURP = Console.ReadLine();
            Console.Write("Ingrese el Rol: ");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            // ML.Result result = BL.Usuario.Add(usuario);

            //ML.Result result = BL.Usuario.AddSP(usuario);

            //ML.Result result = BL.Usuario.AddEF(usuario);

            ML.Result result = BL.Usuario.AddLINQ(usuario);
            
            if (result.Correct)
            {
                Console.WriteLine("Mensaje" + result.Message);
            }

        }

        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Id del usuario a modificar: ");

            usuario.IdUsuario = int.Parse(Console.ReadLine());

            Console.WriteLine("Por favor ingresar la infomacion a modificar");
            Console.Write("Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Apellido Paterno: ");
            usuario.ApellidoPaterno = Console.ReadLine();
            Console.Write("Apellido Materno: ");
            usuario.ApellidoMaterno = Console.ReadLine();
            Console.Write("Fecha de nacimiento (dd-mm-yyyy): ");
            usuario.FechaNacimiento = Console.ReadLine();
            Console.Write("Genero (M: Masculino, F: Fememino): ");
            usuario.Sexo= Console.ReadLine();
            Console.Write("Ingrese su Email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese su nombre de usuario: ");
            usuario.UserName = Console.ReadLine();
            Console.Write("Ingrese su contraseña: ");
            usuario.Password = Console.ReadLine();
            Console.Write("Ingrese su número de telefono: ");
            usuario.Telefono = Console.ReadLine();
            Console.Write("Ingrese su número de celular: ");
            usuario.Celular = Console.ReadLine();
            Console.Write("Ingrese su CURP: ");
            usuario.CURP = Console.ReadLine();
            Console.Write("Ingrese el Rol: ");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());


            //ML.Result result = BL.Usuario.Update(usuario);

            // ML.Result result = BL.Usuario.UpdateSP(usuario);

            //ML.Result result = BL.Usuario.UpdateEF(usuario);

            ML.Result result = BL.Usuario.UpdateLINQ(usuario);
            if (result.Correct)
            {
                Console.WriteLine("Mensaje" + result.Message);
            }
        }


        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el Id del usuario a eliminar: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            // ML.Result result = BL.Usuario.Delete(usuario.IdUsuario);

            //ML.Result result = BL.Usuario.DeleteSP(usuario.IdUsuario);

            //ML.Result result = BL.Usuario.DeleteEF(usuario.IdUsuario);

            ML.Result result = BL.Usuario.DeleteLINQ(usuario.IdUsuario);

            if (result.Correct)
            {
                Console.WriteLine("Mensaje" + result.Message);
            }

        }
        
        public static void GetAll()
        {
            //ML.Result result = BL.Usuario.GetAll();

            //ML.Result result = BL.Usuario.GetAllEF();

            ML.Result result = BL.Usuario.GetAllLINQ();

            if(result.Correct)
            {
                foreach(ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("El id del usuario es: " + usuario.IdUsuario);
                    Console.WriteLine("El nombre del usuario es: " + usuario.Nombre);
                    Console.WriteLine("El apellido paterno del usuario es: "+ usuario.ApellidoPaterno);
                    Console.WriteLine("El apellido materno del usuario es: " + usuario.ApellidoMaterno);
                    Console.WriteLine("La fecha de nacimiento es: " + usuario.FechaNacimiento);
                    Console.WriteLine("El Sexo del usuario es: " + usuario.Sexo);
                    Console.WriteLine("El Email del usuario es: " + usuario.Email);
                    Console.WriteLine("El nombre de usuario es: " + usuario.UserName);
                    Console.WriteLine("La contraseña es: " + usuario.Password);
                    Console.WriteLine("El número de telefono es: " + usuario.Telefono);
                    Console.WriteLine("El número de celular es: " + usuario.Celular);
                    Console.WriteLine("El CURP es: " + usuario.CURP);
                    Console.WriteLine("El Rol es: " + usuario.Rol.IdRol);
                    Console.WriteLine("---------------------------------------------------------\n");
                }
            }

        }

        public static void GetById()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.Write("Ingrese el ID para realizar la consulta: ");
            usuario.IdUsuario = int.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.GetById(usuario.IdUsuario);
            //ML.Result result = BL.Usuario.GetByIdEF(usuario.IdUsuario);
            ML.Result result = BL.Usuario.GetByIdLINQ(usuario.IdUsuario);


            if(result.Correct)
            {
                usuario = (ML.Usuario)result.Object;

                Console.WriteLine("El id del usuario es: " + usuario.IdUsuario);
                Console.WriteLine("El nombre del usuario es: " + usuario.Nombre);
                Console.WriteLine("El apellido parterno del usuarios es: " + usuario.ApellidoPaterno);
                Console.WriteLine("El apellido materno del usuario es: " + usuario.ApellidoMaterno);
                Console.WriteLine("La fecha de nacimiento del usuaruos es: " + usuario.FechaNacimiento);
                Console.WriteLine("El Sexo del usuario es: " + usuario.Sexo);
                Console.WriteLine("El Email del usuario es: " + usuario.Email);
                Console.WriteLine("El nombre de usuario es: " + usuario.UserName);
                Console.WriteLine("La contraseña es: " + usuario.Email);
                Console.WriteLine("El número de telefono del usuario es: " + usuario.Telefono);
                Console.WriteLine("El número de celular del usuario es: " + usuario.Celular);
                Console.WriteLine("El CURP del usuario es: " + usuario.CURP);
                Console.WriteLine("El rol del usuario es: " + usuario.Rol.IdRol);
                Console.WriteLine("----------------------------------------------------------");

            }

        }
    }
}
