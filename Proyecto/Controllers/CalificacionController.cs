using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using Proyecto.Models;

namespace Proyecto.Controllers
{
    [Authorize]
    [AuthorizeRole(Role.Profesor, Role.Estudiante)]
    public class CalificacionController : Controller
    {

        clsCalificacion ObjCalificacion = new clsCalificacion();
        // GET: Calificacion

        public ActionResult Index()
        {
            try
            {
                var datos = ObjCalificacion.ConsultarCalificacion();

                List<Calificacion> ListaCalificacions = new List<Calificacion>();

                foreach (var item in datos)
                {
                    Calificacion calificacion = new Calificacion();
                    calificacion.IdCalificacion = item.IdCalificacion;
                    calificacion.IdTipoOperacion = item.IdTipoOperacion;
                    calificacion.IdEstudiante = item.IdEstudiante;
                    calificacion.IdDocente = item.IdDocente;
                    calificacion.IdMateria = item.IdMateria;
                    calificacion.Nota = item.Nota;
                    calificacion.Fecha = item.Fecha;


                    ListaCalificacions.Add(calificacion);
                }
                return View(ListaCalificacions);
            }
            catch (Exception)
            {
                return View();
                throw;
            }

        }
        public ActionResult Detalle(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpNotFoundResult("Dato  no encontrado");
            }
            else
            {
                var dato = ObjCalificacion.ConsultaCalificacion(Convert.ToInt32(id));

                Calificacion calificacion = new Calificacion();
                calificacion.IdCalificacion = dato.IdCalificacion;
                calificacion.IdTipoOperacion = dato.IdTipoOperacion;
                calificacion.IdEstudiante = dato.IdEstudiante;
                calificacion.IdDocente = dato.IdDocente;
                calificacion.IdMateria = dato.IdMateria;
                calificacion.Nota = dato.Nota;
                calificacion.Fecha = dato.Fecha;
                return View(calificacion);
            }

        }
        public ActionResult Editar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpNotFoundResult("Dato  no encontrado");
            }
            else
            {
                var dato = ObjCalificacion.ConsultaCalificacion(Convert.ToInt32(id));

                Calificacion calificacion = new Calificacion();
                calificacion.IdCalificacion = dato.IdCalificacion;
                calificacion.IdTipoOperacion = dato.IdTipoOperacion;
                calificacion.IdEstudiante = dato.IdEstudiante;
                calificacion.IdDocente = dato.IdDocente;
                calificacion.IdMateria = dato.IdMateria;
                calificacion.Nota = dato.Nota;
                calificacion.Fecha = dato.Fecha;
                return View(calificacion);
            }

        }
        [HttpPost]
        public ActionResult Editar(Calificacion calificacion)
        {
            try
            {
                if (ObjCalificacion.ActualizarCalificacion(calificacion.IdCalificacion,calificacion.IdTipoOperacion,calificacion.IdEstudiante,
                calificacion.IdDocente,calificacion.IdMateria,calificacion.Nota, calificacion.Fecha))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return View();
                throw;
            }


        }
        public ActionResult Crear()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Crear(Calificacion calificacion)
        {
            try
            {
                if (ObjCalificacion.AgregarCalificacion(calificacion.IdTipoOperacion, calificacion.IdEstudiante,
                calificacion.IdDocente, calificacion.IdMateria, calificacion.Nota, calificacion.Fecha))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return View();
                throw;
            }


        }
        public ActionResult Eliminar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpNotFoundResult("Dato  no encontrado");
            }
            else
            {
                var dato = ObjCalificacion.ConsultaCalificacion(Convert.ToInt32(id));

                Calificacion calificacion = new Calificacion();
                calificacion.IdCalificacion = dato.IdCalificacion;
                calificacion.IdTipoOperacion = dato.IdTipoOperacion;
                calificacion.IdEstudiante = dato.IdEstudiante;
                calificacion.IdDocente = dato.IdDocente;
                calificacion.IdMateria = dato.IdMateria;
                calificacion.Nota = dato.Nota;
                calificacion.Fecha = dato.Fecha;
                return View(calificacion);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(Calificacion Calificacion)
        {
            if (ObjCalificacion.EliminarCalificacion(Calificacion.IdCalificacion))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
    }
}