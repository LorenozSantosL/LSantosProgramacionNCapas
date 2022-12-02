using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {

        public static ML.Result Add(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "INSERT INTO [Departamento]([Nombre],[IdArea])VALUES(@Nombre,@IdArea)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;

                        collection[1] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[1].Value = departamento.Area.IdArea;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected >= 1)
                        {
                            result.Message = "Se ha agregado el departamento";
                        }

                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "No se ha podido agregar el departamento";
                throw;
            }

            return result;
        }


        // Stored Procedure
        public static ML.Result AddSP(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "DepartamentoAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querySP;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;

                        collection[1] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[1].Value = departamento.Area.IdArea;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected >= 1)
                        {
                            result.Message = "Se ha agregado el departamento";
                        }
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "No se ha podido agregar el departamento";
                throw;
            }


            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "DepartamentoGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querySP;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        DataTable departamentoTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(departamentoTable);

                        if (departamentoTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in departamentoTable.Rows)
                            {
                                ML.Departamento departamento = new ML.Departamento();

                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();

                                departamento.Area = new ML.Area();
                                departamento.Area.IdArea = int.Parse(row[2].ToString());

                                result.Objects.Add(departamento);
                            }
                        }

                    }
                }
                result.Correct = true;

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "No pudo realizar la consulta";
                throw;
            }


            return result;
        }

        public static ML.Result GetById(int IdDepartamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "DepartamentoGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querySP;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = IdDepartamento;

                        cmd.Parameters.AddRange(collection);

                        DataTable departamentoTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(departamentoTable);

                        if(departamentoTable.Rows.Count > 0)
                        {
                            DataRow row = departamentoTable.Rows[0];

                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = int.Parse(row[0].ToString());
                            departamento.Nombre = row[1].ToString();

                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = int.Parse(row[2].ToString());

                            result.Object = departamento;


                        }

                        
                    }
                }
                result.Correct = true;
            }

            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "No se ha podido obtener la consulta";
                throw;
            }


            return result;
        }

        public static ML.Result UpdateSP(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "DepartamentoUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = departamento.IdDepartamento;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = departamento.Nombre;

                        collection[2] = new SqlParameter("IdArea", SqlDbType.Int);
                        collection[2].Value = departamento.Area.IdArea;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected >= 1)
                        {
                            result.Message = "Se ha acutalizado el departamento";
                        }
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex )
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ha ocurrido un error en modificar el departamento";
                throw;
            }


            return result;
        }

        public static ML.Result Delete(int IdDepartamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "DepartamentoDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querySP;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.Int);
                        collection[0].Value = IdDepartamento;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected >= 1)
                        {
                            result.Message = "Se ha eliminado el departaamento";
                        }
                    }
                }
                result.Correct = true;

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al intenar borrar el registro";
                throw;
            }

            return result;
        }

        // Entities Framework
        public static ML.Result AddEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    int query = context.DepartamentoAdd(departamento.Nombre, departamento.Area.IdArea);

                    if(query > 0)
                    {
                        result.Message = "Se ha agreado el departamento";
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ha ocurrido un error al agregar el departamento";
                throw;
            }

            return result;
        }

        public static ML.Result UpdateEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    int query = context.DepartamentoUpdate(departamento.IdDepartamento, departamento.Nombre, departamento.Area.IdArea);

                    if (query > 0)
                    {
                        result.Message = "SE ha actualizado el departamento";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ha ocurrido un error al intentar actualizar los datos";
                throw;
            }
            return result;
        }

        public static ML.Result DeleteEF(int IdDepartamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    int query = context.DepartamentoDelete(IdDepartamento);

                    if(query > 0)
                    {
                        result.Message = "Se ha eliminado el departamento";
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "No se pudo eliminar el departamento";
                throw;
            }

            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var departamentos = context.DepartamentoGetAll().ToList();

                    result.Objects = new List<object>();

                    if(departamentos != null)
                    {
                        foreach (var obj in departamentos)
                        {
                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.Nombre;

                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = obj.IdArea;


                            result.Objects.Add(departamento);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Message = ex.Message;
                result.Message = "Ocurrio un error en obtener los datos ";
                throw;
            }

            return result;
        }

        public static ML.Result GetByIdEF(int IdDepartamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var objDepartamento = context.DepartamentoGetById(IdDepartamento).SingleOrDefault();

                    result.Object = new List<object>();

                    if(objDepartamento != null)
                    {
                        ML.Departamento departamento = new ML.Departamento();

                        departamento.IdDepartamento = objDepartamento.IdDepartamento;
                        departamento.Nombre = objDepartamento.Nombre;

                        departamento.Area = new ML.Area();
                        departamento.Area.IdArea = objDepartamento.IdArea;

                        result.Object = departamento;
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "No se pudo obtener el regsitro";
                throw;
            }

            return result;
        }


        //LINQ

        public static ML.Result AddLINQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    DL_EF.Departamento departamentoDL = new DL_EF.Departamento();

                    departamentoDL.Nombre = departamento.Nombre;
                    departamentoDL.IdArea = departamento.Area.IdArea;

                    context.Departamentoes.Add(departamentoDL);

                    var queryResult= context.SaveChanges();

                    if(queryResult >=1)
                    {
                        result.Message = "Se ha agregado el deartamento";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se insert el departamento";
                    }
                }
               
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "No se pudo agrear el departamento";
                throw;
            }

            return result;
        }

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var query = (from departamentoTDB in context.Departamentoes
                                 select new
                                 {
                                     IdDepartamento = departamentoTDB.IdDepartamento,
                                     Nombre = departamentoTDB.Nombre,
                                     IdArea = departamentoTDB.IdArea
                                 }
                                ).ToList();

                    result.Objects = new List<object>();

                    if(query != null && query.ToList().Count > 0)
                    {
                        foreach( var obj in query)
                        {
                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = obj.IdDepartamento;
                            departamento.Nombre = obj.Nombre;

                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = obj.IdArea;

                            result.Objects.Add(departamento);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron los registros";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al obtener los registros";
                throw;
            }

            return result;
        }

        public static ML.Result GetByIdLINQ(int IdDepartamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var query = (from departamentoTDB in context.Departamentoes
                                 where departamentoTDB.IdDepartamento == IdDepartamento
                                 select new
                                 {
                                     IdDepartamento = departamentoTDB.IdDepartamento,
                                     Nombre = departamentoTDB.Nombre,
                                     IdArea = departamentoTDB.IdArea
                                 }).SingleOrDefault();

                    if(query != null)
                    {
                        ML.Departamento departamento = new ML.Departamento();

                        departamento.IdDepartamento = query.IdDepartamento;
                        departamento.Nombre = query.Nombre;

                        departamento.Area = new ML.Area();
                        departamento.Area.IdArea = query.IdArea;


                        result.Object = departamento;

                        result.Correct = true;
                    }


                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "No se ha podido obtener el departamento";
                throw;
            }

            return result;
        }

        public static ML.Result UpdateLINQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var query = (from departamentoTDB in context.Departamentoes
                                 where departamentoTDB.IdDepartamento == departamento.IdDepartamento
                                 select departamentoTDB).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = departamento.Nombre;

                        query.IdArea = departamento.Area.IdArea;

                        var queryResult = context.SaveChanges();

                        if (queryResult >= 1)
                        {
                            result.Correct = true;
                            result.Message = "SE ha actualizado el departamento";
                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se insert el departamento";
                        }
                        

                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "Ocurrio un error al encontrar el departamento";
                    }


                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error";
                throw;
            }

            return result;
        }

        public static ML.Result DeleteLINQ(int IdDepartamento)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var query = (from departamentoTDB in context.Departamentoes
                                 where departamentoTDB.IdDepartamento == IdDepartamento
                                 select departamentoTDB).First();

                    context.Departamentoes.Remove(query);
                    context.SaveChanges();

                }
                result.Correct = true;
                result.Message = "Se ha eliminado el departamento";
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ourrio un error al elimnar el departamento";
                throw;
            }

            return result;
        }
    }

    
}
