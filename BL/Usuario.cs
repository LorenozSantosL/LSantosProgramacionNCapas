using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()) )
                {
                    string query = "INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[FechaNacimiento],[Sexo],[Email],[UserName],[Password],[Telefono],[Celular],[CURP],[IdRol])VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@FechaNacimiento,@Sexo,@Email,@UserName,@Password,@Telefono,@Celular,@CURP,@IdRol)";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        context.Open();


                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[4].Value = usuario.Sexo;

                        collection[5] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[5].Value = usuario.Email;

                        collection[6] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[6].Value = usuario.UserName;

                        collection[7] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;

                        collection[11] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[11].Value = usuario.Rol.IdRol;



                        cmd.Parameters.AddRange(collection);


                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego correctamente al usuario";
                        }
                    }
                }
                result.Correct = true;

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al insertar al usuario" + result.EX;

                throw;
            }
            return result;
        }

        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))

                {
                    string query = "UsuarioAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[3].Value = usuario.FechaNacimiento;

                        collection[4] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[4].Value = usuario.Sexo;

                        collection[5] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[5].Value = usuario.Email;

                        collection[6] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[6].Value = usuario.UserName;

                        collection[7] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[8].Value = usuario.Telefono;

                        collection[9] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[9].Value = usuario.Celular;

                        collection[10] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[10].Value = usuario.CURP;

                        collection[11] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[11].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego el usuario correctamente con Stored Procedure";
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al insertar al usuario";

                throw;
            }



            return result;

        }

       public static ML.Result Update(ML.Usuario usuario)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UPDATE [Usuario] SET [Nombre]=@Nombre,[ApellidoPaterno]=@ApellidoPaterno,[ApellidoMaterno]=@ApellidoMaterno,[FechaNacimiento]=@FechaNacimiento,[Sexo]=@Sexo,[Email]=@Email,[UserName]=@UserName,[Password]=@Password,[Telefono]=@Telefono,[Celular]=@Celular,[CURP]=@CURP,[IdRol]=@IdRol WHERE IdUsuario=@IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        context.Open();


                        SqlParameter[] collection = new SqlParameter[13];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[4].Value = usuario.FechaNacimiento;

                        collection[5] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[5].Value = usuario.Sexo;

                        collection[6] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[6].Value = usuario.Email;

                        collection[7] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[7].Value = usuario.UserName;

                        collection[8] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[8].Value = usuario.Password;

                        collection[9] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[9].Value = usuario.Telefono;

                        collection[10] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[10].Value = usuario.Celular;

                        collection[11] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[11].Value = usuario.CURP;

                        collection[12] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[12].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se modifico correctamente ";
                        }

                    }
                }
                result.Correct = true;

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al insertar al usuario" + result.EX;
            }



            return result;
        }

        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "UsuarioUpdate";

                    using (SqlCommand cmd = new  SqlCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = querySP;
                        cmd.CommandType = CommandType.StoredProcedure;

                        contex.Open();

                        SqlParameter[] collection = new SqlParameter[13];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[4].Value = usuario.FechaNacimiento;

                        collection[5] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[5].Value = usuario.Sexo;

                        collection[6] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[6].Value = usuario.Email;

                        collection[7] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[7].Value = usuario.UserName;

                        collection[8] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[8].Value = usuario.Password;

                        collection[9] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[9].Value = usuario.Telefono;

                        collection[10] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[10].Value = usuario.Celular;

                        collection[11] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[11].Value = usuario.CURP;

                        collection[12] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[12].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected >= 0)
                        {
                            result.Message = "Se actualizo el usuario con stored Procedure";
                        }
                    }
                }
                result.Correct = true;
            }
            catch ( Exception ex)
            {
                result.Correct=false;
                result.EX = ex;
                result.Message = "Ocurrio un error al actualizar los datos";
            }


            return result;
        }


        public static ML.Result Delete(int usuarioId)
        {

            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "DELETE FROM [Usuario] WHERE IdUsuario=@IdUsuario";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuarioId;


                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected >= 1)
                        {
                            result.Message = "Se ha eliminado el registro";
                        }


                    }

                }
                result.Correct=true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al eliminar el registro" + result.EX;
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
                    string querySP = "UsuarioGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querySP;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(usuarioTable);

                        if(usuarioTable.Rows.Count > 0)
                        {
                            result.Objects = new List<Object>();

                            foreach(DataRow row in usuarioTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoMaterno = row[3].ToString();
                                usuario.FechaNacimiento = row[4].ToString();
                                usuario.Sexo = row[5].ToString();
                                usuario.Email = row[6].ToString();
                                usuario.UserName = row[7].ToString();
                                usuario.Password = row[8].ToString();
                                usuario.Telefono = row[9].ToString();
                                usuario.Celular = row[10].ToString();
                                usuario.CURP = row[11].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = byte.Parse(row[12].ToString());

                                result.Objects.Add(usuario); //boxing
                            }
                        }
                    }
                }

                result.Correct = true;

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al solicitar los datos";
                throw;
            }

            return result;
        }

        public static ML.Result DeleteSP(int usuarioId)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UsuarioDelete";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuarioId;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected >= 1)
                        {
                            result.Message = "Se ha eliminado el registro";
                        }
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ha ocurrido un error al elimar el registro";

            }


                return result;
        }

        public static ML.Result GetById(int usuarioId)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string querySP = "UsuarioGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = querySP;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = usuarioId;


                        cmd.Parameters.AddRange(collection);

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {
                            DataRow row = usuarioTable.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = int.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.FechaNacimiento = row[4].ToString();
                            usuario.Sexo =row[5].ToString();
                            usuario.Email = row[6].ToString();
                            usuario.UserName = row[7].ToString();
                            usuario.Password = row[8].ToString();
                            usuario.Telefono = row[9].ToString();
                            usuario.Celular = row[10].ToString();
                            usuario.CURP = row[11].ToString();

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = byte.Parse(row[12].ToString());

                            result.Object = usuario;

                        }

                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "No se encontro el usuario";
                throw;
            }
            

            return result;
        }

        //Entities Framework
        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    int query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Sexo, usuario.Email, usuario.UserName, usuario.Password, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Rol.IdRol, usuario.Imagen, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                
                    if(query >0)
                    {
                        result.Message = "Se ha agregado el usuario correctamente";
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al agregar al usuario";
                throw;
            }

            return result;
        }

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    int query = context.UsuarioUpdate(usuario.IdUsuario, usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.FechaNacimiento, usuario.Sexo, usuario.Email, usuario.UserName, usuario.Password, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.Rol.IdRol, usuario.Imagen , usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);
                
                    if (query > 0)
                    {
                        result.Message = "Se ha actualizado el usuario";
                    }
                
                
                }

                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al actualizar los datos del usuario";
                throw;
            }


            return result;
        }

        public static ML.Result DeleteEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    int query = context.UsuarioDelete(IdUsuario);

                    if(query > 0)
                    {
                        result.Message = "Se ha eliminado el usuario correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "No se ha podido eliminar al usuario";
                throw;
            }

            return result;
        }
        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    usuario.Rol.IdRol = (usuario.Rol.IdRol == null) ? usuario.Rol.IdRol = 0 : usuario.Rol.IdRol;
                    usuario.Nombre = (usuario.Nombre == null) ? usuario.Nombre = "" : usuario.Nombre;
                    usuario.ApellidoPaterno  =(usuario.ApellidoPaterno == null ) ? usuario.ApellidoPaterno = "" : usuario.ApellidoPaterno;
                    var usuarios = context.UsuarioGetAll(usuario.Nombre, usuario.ApellidoPaterno, usuario.Rol.IdRol).ToList();

                    result.Objects = new List<object>();

                    if(usuarios != null)
                    {
                        foreach(var obj in usuarios)
                        {
                            ML.Usuario usuarioGet = new ML.Usuario();
                            usuarioGet.IdUsuario = obj.IdUsuario;
                            usuarioGet.Nombre = obj.Nombre;
                            usuarioGet.ApellidoPaterno = obj.ApellidoPaterno;
                            usuarioGet.ApellidoMaterno = obj.ApellidoMaterno;
                            usuarioGet.FechaNacimiento = obj.FechaNacimiento.ToString("dd-MM-yyyy");
                            usuarioGet.Sexo = obj.Sexo;
                            usuarioGet.Email = obj.Email;
                            usuarioGet.UserName = obj.UserName;
                            usuarioGet.Password = obj.Password;
                            usuarioGet.Telefono = obj.Telefono;
                            usuarioGet.Celular = obj.Celular;
                            usuarioGet.CURP = obj.CURP;

                            usuarioGet.Rol = new ML.Rol();
                            usuarioGet.Rol.IdRol = obj.IdRol.Value;
                            usuarioGet.Rol.Nombre = obj.NombreRol;
                            usuarioGet.Imagen = obj.Imagen;
                            usuarioGet.Estatus = obj.Estatus;

                            usuarioGet.Direccion = new ML.Direccion();
                            usuarioGet.Direccion.IdDireccion = obj.IdDireccion;
                            usuarioGet.Direccion.Calle = obj.Calle;
                            usuarioGet.Direccion.NumeroInterior = obj.NumeroInterior;
                            usuarioGet.Direccion.NumeroExterior = obj.NumeroExterior;

                            usuarioGet.Direccion.Colonia = new ML.Colonia();
                            usuarioGet.Direccion.Colonia.IdColonia = obj.IdColonia.Value;
                            usuarioGet.Direccion.Colonia.Nombre = obj.ColoniaNombre;
                            usuarioGet.Direccion.Colonia.CodigoPostal = obj.CodigoPostal;

                            usuarioGet.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuarioGet.Direccion.Colonia.Municipio.IdMunicipio = obj.IdMunicipio.Value;
                            usuarioGet.Direccion.Colonia.Municipio.Nombre = obj.MunicipioNombre;

                            usuarioGet.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuarioGet.Direccion.Colonia.Municipio.Estado.IdEstado = obj.IdEstado.Value;
                            usuarioGet.Direccion.Colonia.Municipio.Estado.Nombre = obj.EstadoNombre;

                            usuarioGet.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuarioGet.Direccion.Colonia.Municipio.Estado.Pais.IdPais = obj.IdPais.Value;
                            usuarioGet.Direccion.Colonia.Municipio.Estado.Pais.Nombre = obj.PaisNombre;

                            result.Objects.Add(usuarioGet);

                        }
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error en obtener los datos";
                throw;
            }

            return result;
        }

        public static ML.Result GetByIdEF(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var objUsuario = context.UsuarioGetById(IdUsuario).SingleOrDefault();

                    result.Object = new List<object>();

                    if (objUsuario != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = objUsuario.IdUsuario;
                        usuario.Nombre = objUsuario.Nombre;
                        usuario.ApellidoPaterno = objUsuario.ApellidoPaterno;
                        usuario.ApellidoMaterno = objUsuario.ApellidoMaterno;
                        usuario.FechaNacimiento = objUsuario.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.Sexo = objUsuario.Sexo;
                        usuario.Email = objUsuario.Email;
                        usuario.UserName = objUsuario.UserName;
                        usuario.Password = objUsuario.Password;
                        usuario.Telefono = objUsuario.Telefono;
                        usuario.Celular = objUsuario.Celular;
                        usuario.CURP = objUsuario.CURP;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objUsuario.IdRol.Value;
                        usuario.Imagen = objUsuario.Imagen;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = objUsuario.IdDireccion;

                        usuario.Direccion.Calle = objUsuario.Calle;
                        usuario.Direccion.NumeroInterior = objUsuario.NumeroInterior;
                        usuario.Direccion.NumeroExterior = objUsuario.NumeroExterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = objUsuario.IdColonia.Value;
                        usuario.Direccion.Colonia.Nombre = objUsuario.ColoniaNombre;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = objUsuario.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.Nombre = objUsuario.MunicipioNombre;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = objUsuario.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = objUsuario.EstadoNombre;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = objUsuario.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = objUsuario.PaisNombre;



                        result.Object = usuario;
                    }
                }
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;

                result.Message = "Ha ocurrido un error al intentar eliminar al Usuario";
                throw;
            }

            return result;
        }

        //LINQ

        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd-MM-yyyy", null);
                    usuarioDL.Sexo = usuario.Sexo;
                    usuarioDL.Email = usuario.Email;
                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.CURP = usuario.CURP;

                    usuarioDL.IdRol = usuario.Rol.IdRol;


                    context.Usuarios.Add(usuarioDL);
                    var queryResult = context.SaveChanges();

                    if (queryResult >= 1)
                    {
                        result.Correct = true;
                        result.Message = "SE ha agregado el usuario";
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se ha agregado el usuario";
                    }

                }
                result.Message = "Se ha agregado el usuario";
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al agregar el usuario";
                throw; 
            }


            return result;
        }

        public static ML.Result UpdateLINQ(ML.Usuario usuario )
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var query = (from usuarioTDB in context.Usuarios
                                 where usuarioTDB.IdUsuario == usuario.IdUsuario
                                 select usuarioTDB).SingleOrDefault();

                    if(query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.FechaNacimiento = DateTime.ParseExact(usuario.FechaNacimiento, "dd-mm-yyyy", null);
                        query.Sexo = usuario.Sexo;
                        query.Email = usuario.Email;
                        query.UserName = usuario.UserName;
                        query.Password = usuario.Password;
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        query.CURP = usuario.CURP;
                        query.IdRol = usuario.Rol.IdRol;

                        var queryResult = context.SaveChanges();

                        if (queryResult >= 1)
                        {
                            result.Correct = true;
                            result.Message = "Se ha actualizado el usuario";

                        }
                        else
                        {
                            result.Correct = false;
                            result.Message = "No se ha actualizado el usuario";
                        }

                        
                    }

                    else
                    {
                        result.Correct = false;
                        result.Message = "Ocurrio un error a encontrar el usuario:  " +usuario.IdUsuario;
                    }
                }

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "No se pudo actualizar el usuario";
            }
            return result;
        }

        public static ML.Result DeleteLINQ(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var query = (from usuarioTDB in context.Usuarios
                                 where usuarioTDB.IdUsuario == IdUsuario
                                 select usuarioTDB).First();

                    context.Usuarios.Remove(query);
                    context.SaveChanges();

                    
                    
                        
                }
                result.Message = "Se ha eliminado el usuario";
                result.Correct = true;
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al intentar eliminar al usuario";

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
                    var query = (from usuarioTDB in context.Usuarios
                                 select new { 
                                     IdUsuario = usuarioTDB.IdUsuario,
                                     Nombre = usuarioTDB.Nombre, 
                                     ApelllidoPaterno = usuarioTDB.ApellidoPaterno,
                                     ApellidoMaterno = usuarioTDB.ApellidoMaterno, 
                                     FechaNacimiento = usuarioTDB.FechaNacimiento, 
                                     Sexo = usuarioTDB.Sexo,
                                     Email = usuarioTDB.Email,
                                     UserName = usuarioTDB.UserName, 
                                     Password = usuarioTDB.Password, 
                                     Telefono = usuarioTDB.Telefono,
                                     Celular = usuarioTDB.Celular, 
                                     CURP = usuarioTDB.CURP,
                                     IdRol = usuarioTDB.IdRol }
                        ).ToList();
                    
                    result.Objects = new List<object>();
                    if(query != null && query.ToList().Count > 0)
                    {
                        foreach(var obj in query )
                            {

                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = obj.IdUsuario;
                            usuario.Nombre = obj.Nombre;
                            usuario.ApellidoPaterno = obj.ApelllidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.FechaNacimiento = obj.FechaNacimiento.ToString("dd-mm-yyyy");
                            usuario.Sexo = obj.Sexo;
                            usuario.Email = obj.Email;
                            usuario.UserName = obj.UserName;
                            usuario.Password = obj.Password;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.CURP = obj.CURP;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IdRol.Value;



                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                       
                    }
                    else
                    {
                        result.Correct = false;
                        result.Message = "No se encontraron registros";
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

        public static ML.Result GetByIdLINQ(int IdUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL_EF.LSantosProgramacionNCapasEntities context = new DL_EF.LSantosProgramacionNCapasEntities())
                {
                    var query = (from usuarioTBD in context.Usuarios
                                 where usuarioTBD.IdUsuario == IdUsuario
                                 select new
                                 {
                                     IdUsuario = usuarioTBD.IdUsuario,
                                     Nombre = usuarioTBD.Nombre,
                                     ApellidoPaterno = usuarioTBD.ApellidoPaterno,
                                     ApellidoMaterno = usuarioTBD.ApellidoMaterno,
                                     FechaNacimiento = usuarioTBD.FechaNacimiento,
                                     Sexo = usuarioTBD.Sexo,
                                     Email = usuarioTBD.Email,
                                     UserName = usuarioTBD.UserName,
                                     Password = usuarioTBD.Password,
                                     Telefono = usuarioTBD.Telefono,
                                     Celular = usuarioTBD.Celular,
                                     CURP = usuarioTBD.CURP,
                                     IdRol = usuarioTBD.IdRol
                                 }
                                  ).SingleOrDefault();


                    if(query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString("dd-mm-yyyy");
                        usuario.Sexo = query.Sexo;
                        usuario.Email = query.Email;
                        usuario.UserName = query.UserName;
                        usuario.Password = query.Password;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.CURP = query.CURP;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;


                        result.Object = usuario;

                        result.Correct = true;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.EX = ex;
                result.Message = "Ocurrio un error al intener obtener al usuario";
                throw;
            }

            return result;
        }

    }
}
