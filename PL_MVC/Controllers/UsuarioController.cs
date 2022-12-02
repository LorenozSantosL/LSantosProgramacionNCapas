using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet] //Se refiere al actionVerb
        public ActionResult GetAll()
        {
            ML.Result result = BL.Usuario.GetAllEF();
            ML.Usuario usuario = new ML.Usuario();
            if (result.Correct)
            {

                usuario.Usuarios = result.Objects;   //guardamos la lista de objetos en una lista de usuarios 
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta ";
            }

            return View(usuario);
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            ML.Result resultPais = BL.Pais.GetAll();
            ML.Result resultRol = BL.Rol.GetAllEF();
            

            if(IdUsuario == null)
            {
                usuario.Rol.Roles = resultRol.Objects;
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                return View(usuario);
            }
            else
            {
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);

                if (result.Correct) {

                    usuario = (ML.Usuario)result.Object;
                    usuario.Rol.Roles = resultRol.Objects;

                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;

                    ML.Result resulEstado = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resulEstado.Objects;

                    ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;

                    ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    usuario.Direccion.Colonia.Colonias = resultColonia.Objects;

                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar al usuario seleccionado";
                }
                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if(usuario.IdUsuario == 0 )
            {
                HttpPostedFileBase FileBase = Request.Files["inputImagen"];  //obtener un archivo en este caso de imagen


                if(FileBase.ContentLength > 0 )
                {
                    usuario.Imagen = ConvertToBytes(FileBase);
                }



                ML.Result result = BL.Usuario.AddEF(usuario);

                if(result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Messsage = "Error:  " + result.Message;
                }
            }

            else
            {
                HttpPostedFileBase FileBase = Request.Files["inputImagen"];

  
                    if(FileBase.ContentLength > 0 )
                    {
                        usuario.Imagen = ConvertToBytes(FileBase);
                    }
                
  

                ML.Result result = BL.Usuario.UpdateEF(usuario);

                if(result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }
            return PartialView("Modal");
        }

       [HttpGet]
        public ActionResult Delete(int IdUsuario)
        {

            if(IdUsuario > 0)
            {
                ML.Result result = BL.Usuario.DeleteEF(IdUsuario);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;

                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }
            

            return PartialView("Modal");
        }
       
        public JsonResult GetEstado(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipio( int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColonia( int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);

        }

        
        public Byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;

            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);

            data = reader.ReadBytes((int)Imagen.ContentLength);


            return data;
        }

        
    }
}