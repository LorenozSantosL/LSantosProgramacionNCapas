using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    {

        public static ML.Result GetByIdPais(int IdPais )
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var queryEstados = context.EstadoGetByIdPais(IdPais).ToList();
                    result.Objects = new List<object>();

                    if(queryEstados != null)
                    {
                        foreach(var objEstado in queryEstados)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = objEstado.IdEstado;
                            estado.Nombre = objEstado.Nombre;
                            
                            estado.Pais = new ML.Pais();
                            estado.Pais.IdPais = IdPais;

                            result.Objects.Add(estado);
                        }
                    }

                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al realizar la consulta " + result.EX;
                throw;
            }

            return result;
        }
    }
}
