using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var queryPaises = context.PaisGetAll().ToList();

                    result.Objects = new List<object>();

                    if (queryPaises != null)
                    {
                        foreach (var objPais in queryPaises)
                        {
                            ML.Pais pais = new ML.Pais();

                            pais.IdPais = objPais.IdPais;
                            pais.Nombre = objPais.Nombre;

                            result.Objects.Add(pais);
                        }
                    }
                }
                    result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "No se pudo realizar la consulta" + result.EX;
                throw;
            }

            return result;
        }
    }
}
