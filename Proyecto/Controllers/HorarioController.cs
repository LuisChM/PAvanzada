using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    [Authorize]
    [AuthorizeRole(Role.Profesor, Role.Estudiante)]
    public class HorarioController : Controller
    {
        clsHorario ObjHorario = new clsHorario();
        // GET: Horario
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ObtenerHorarios()
        {

                var events = ObjHorario.ConsultarHorario().ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
        [HttpPost]
        public JsonResult Guardar(Horario horario)
        {
            Session["Grado"] = 4;
            var status = false;

            if (horario.IdHorario > 0)
            {
                //Actualiza Horario
                if (ObjHorario.ActualizaHorario(horario.IdHorario, horario.Materia, Convert.ToInt32(Session["Grado"].ToString()), horario.Descripcion, horario.Inicio, horario.Fin, horario.ColorFondo, horario.DiaCompleto))
                {
                    status = true;
                }
                else
                {
                    status = false;
                }

            }
            else
            {
                if (ObjHorario.AgregaHorario(horario.Materia, Convert.ToInt32(Session["Grado"].ToString()), horario.Descripcion, horario.Inicio, horario.Fin, horario.ColorFondo, horario.DiaCompleto))
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult Eliminar(int idHorario)
        {
            var status = false;

            if (ObjHorario.EliminaHorario(idHorario))
            {
                status = true;
            }
            else
            {
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}