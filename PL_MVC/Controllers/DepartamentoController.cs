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
            ML.Result result = BL.Departamento.GetAllEF();
            ML.Departamento departamento = new ML.Departamento();

            if(result.Correct)
            {
                departamento.Departamentos = result.Objects;
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

            if(IdDepartamento == null)
            {
                return View();
            }
            else
            {
                ML.Result result = BL.Departamento.GetByIdEF(IdDepartamento.Value);

                if(result.Correct)
                {
                    departamento = (ML.Departamento)result.Object;
                    
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al consultar el departamento seleccionado";
                }
                return View(departamento);
            }
        }
    }
}