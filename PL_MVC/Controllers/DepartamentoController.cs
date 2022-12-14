using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class DepartamentoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {

            //ServiceDepartamento.DepartamentoClient context = new ServiceDepartamento.DepartamentoClient();

            ServiceDepartamento.DepartamentoClient context = new ServiceDepartamento.DepartamentoClient();

            var result = context.GetAll();
            
            //ML.Result result = BL.Departamento.GetAllEF();
            ML.Departamento departamento = new ML.Departamento();
            departamento.Departamentos = new List<object>();
            if(result.Correct)
            {
                //departamento.Departamentos = (ML.Departamento)result.Objects;
                foreach(var obj in result.Objects)
                {
                    departamento.Departamentos.Add(obj);
                }

                //departamento.Departamentos = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }

            return View(departamento);
        }

        [HttpGet]
        public ActionResult Form(int? IdDepartamento)
        {

            ML.Departamento departamento = new ML.Departamento();
          
            departamento.Area = new ML.Area();
            ML.Result resultArea = BL.Area.GetAll();

            if(IdDepartamento == null)
            {
                departamento.Area.Areas = resultArea.Objects;
                return View(departamento);
            }
            else
            {
                ServiceDepartamento.DepartamentoClient context = new ServiceDepartamento.DepartamentoClient();

                var result = context.GetById(IdDepartamento.Value);

                //ML.Result result = BL.Departamento.GetByIdEF(IdDepartamento.Value);

                if(result.Correct)
                {
                    departamento = (ML.Departamento)result.Object;
                    departamento.Area.Areas = resultArea.Objects;
                    
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el departamento seleccionado";
                }
                return View(departamento);
            }
        }


        [HttpPost]
        public ActionResult Form(ML.Departamento departamento)
        {
            if (departamento.IdDepartamento == 0)
            {
                ServiceDepartamento.DepartamentoClient context = new ServiceDepartamento.DepartamentoClient();

                var result = context.Add(departamento);

                //ML.Result result = BL.Departamento.Add(departamento);

                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }

            }
            else
            {
                //ML.Result result = BL.Departamento.Update(departamento);

                ServiceDepartamento.DepartamentoClient context = new ServiceDepartamento.DepartamentoClient();

                var result = context.Update(departamento);
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



        public ActionResult Delete(int IdDepartamento)
        {
            if(IdDepartamento > 0)
            {
                ServiceDepartamento.DepartamentoClient context = new ServiceDepartamento.DepartamentoClient();

                var result = context.Delete(IdDepartamento);

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


    }
}