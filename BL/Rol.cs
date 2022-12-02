using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var query = context.RolGetAll().ToList();

                    if(query != null)
                    {
                        result.Objects = new List<object>();

                        foreach( var row in query)
                        {
                            ML.Rol rol = new ML.Rol();

                            rol.IdRol = row.IdRol;
                            rol.Nombre = row.Nombre;


                            result.Objects.Add(rol);
                        }
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;

                result.EX = ex;

                result.Message = "Ocurrio un erro al obtener los datos " + ex;
                throw;
            }

            return result;
        }
    }
}
