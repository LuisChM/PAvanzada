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
    public class MateriaController : Controller
    {

        clsMateria ObjMateria = new clsMateria();
        clsInstitucion ObjInstitucion = new clsInstitucion();

        // GET: Materia

        public ActionResult Index()
        {
            try
            {
                var datos = ObjMateria.ConsultarMateria();

                List<Materia> ListaMaterias = new List<Materia>();

                foreach (var item in datos)
                {
                    Materia materia = new Materia();
                    materia.IdMateria = item.IdMateria;
                    materia.Descripcion = item.Descripcion;
                    materia.IdInstitucion = item.IdInstitucion;
                    materia.Estado = item.Estado;

                    ListaMaterias.Add(materia);
                }
                return View(ListaMaterias);
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
                var dato = ObjMateria.ConsultaMateria(Convert.ToInt32(id));

                Materia materia = new Materia();
                materia.IdMateria = dato.IdMateria;
                materia.Descripcion = dato.Descripcion;
                materia.IdInstitucion = dato.IdInstitucion;
                materia.Estado = dato.Estado;

                ViewBag.Institucion = ConsultarInstitucion();

                return View(materia);
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
                var dato = ObjMateria.ConsultaMateria(Convert.ToInt32(id));

                Materia materia = new Materia();
                materia.IdMateria = dato.IdMateria;
                materia.Descripcion = dato.Descripcion;
                materia.IdInstitucion = dato.IdInstitucion;
                materia.Estado = dato.Estado;

                ViewBag.Institucion = ConsultarInstitucion();

                return View(materia);
            }

        }
        [HttpPost]
        public ActionResult Editar(Materia materia)
        {
            try
            {
                if (ObjMateria.ActualizarMateria(materia.IdMateria, materia.Descripcion, materia.IdInstitucion , materia.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Institucion = ConsultarInstitucion();

                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Institucion = ConsultarInstitucion();

                return View();
                throw;
            }


        }
        public ActionResult Crear()
        {
            ViewBag.Institucion = ConsultarInstitucion();

            return View();

        }
        [HttpPost]
        public ActionResult Crear(Materia materia)
        {
            try
            {
                if (ObjMateria.AgregarMateria(materia.Descripcion, materia.IdInstitucion, materia.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Institucion = ConsultarInstitucion();

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
                var dato = ObjMateria.ConsultaMateria(Convert.ToInt32(id));

                Materia materia = new Materia();
                materia.IdMateria = dato.IdMateria;
                materia.Descripcion = dato.Descripcion;
                materia.IdInstitucion = dato.IdInstitucion;
                materia.Estado = dato.Estado;
                return View(materia);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(Materia materia)
        {
            if (ObjMateria.EliminarMateria(materia.IdMateria))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        #region Datos
        private List<ConsultarInstitucionResult> ConsultarInstitucion()
        {
            var instituciones = ObjInstitucion.ConsultarInstitucion();
            return instituciones;
        }

        #endregion
    }
}