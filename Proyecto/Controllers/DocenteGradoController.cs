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
    [AuthorizeRole(Role.Director)]
    public class DocenteGradoController : Controller
    {

        clsDocenteGrado ObjDocenteGrado = new clsDocenteGrado();
        clsDocente ObjDocente = new clsDocente();
        clsGrado ObjGrado = new clsGrado();


        // GET: DocenteGrado

        public ActionResult Index()
        {
            try
            {
                var datos = ObjDocenteGrado.ConsultarDocenteGrado();

                List<DocenteGrado> ListaDocenteGrados = new List<DocenteGrado>();

                foreach (var item in datos)
                {
                    DocenteGrado docenteGrado = new DocenteGrado();
                   docenteGrado.IdDocenteGrado = item.IdDocenteGrado;
                    docenteGrado.IdDocente = item.IdDocente;
                    docenteGrado.IdGrado = item.IdGrado;

                    ListaDocenteGrados.Add(docenteGrado);
                }
                return View(ListaDocenteGrados);
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
                var dato = ObjDocenteGrado.ConsultaDocenteGrado(Convert.ToInt32(id));

                DocenteGrado docenteGrado = new DocenteGrado();
               docenteGrado.IdDocenteGrado = dato.IdDocenteGrado;
                docenteGrado.IdDocente = dato.IdDocente;
                docenteGrado.IdGrado = dato.IdGrado;
                ViewBag.Docente = ConsultarDocente();
                ViewBag.Grado = ConsultarGrado();

                return View(docenteGrado);
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
                var dato = ObjDocenteGrado.ConsultaDocenteGrado(Convert.ToInt32(id));

                DocenteGrado docenteGrado = new DocenteGrado();
               docenteGrado.IdDocenteGrado = dato.IdDocenteGrado;
               docenteGrado.IdDocente = dato.IdDocente;
               docenteGrado.IdGrado = dato.IdGrado;

                ViewBag.Docente = ConsultarDocente();
                ViewBag.Grado = ConsultarGrado();

                return View(docenteGrado);
            }

        }
        [HttpPost]
        public ActionResult Editar(DocenteGrado docenteGrado)
        {
            try
            {
                if (ObjDocenteGrado.ActualizarDocenteGrado(docenteGrado.IdDocenteGrado,docenteGrado.IdDocente,docenteGrado.IdGrado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Docente = ConsultarDocente();
                    ViewBag.Grado = ConsultarGrado();

                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Docente = ConsultarDocente();
                ViewBag.Grado = ConsultarGrado();

                return View();
                throw;
            }


        }
        public ActionResult Crear()
        {
            ViewBag.Docente = ConsultarDocente();
            ViewBag.Grado = ConsultarGrado();

            return View();

        }
        [HttpPost]
        public ActionResult Crear(DocenteGrado docenteGrado)
        {
            try
            {
                if (ObjDocenteGrado.AgregarDocenteGrado(docenteGrado.IdDocente,docenteGrado.IdGrado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Docente = ConsultarDocente();
                    ViewBag.Grado = ConsultarGrado();

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
                var dato = ObjDocenteGrado.ConsultaDocenteGrado(Convert.ToInt32(id));

                DocenteGrado docenteGrado = new DocenteGrado();
               docenteGrado.IdDocenteGrado = dato.IdDocenteGrado;
               docenteGrado.IdDocente = dato.IdDocente;
               docenteGrado.IdGrado = dato.IdGrado;

                return View(docenteGrado);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(DocenteGrado docenteGrado)
        {
            if (ObjDocenteGrado.EliminarDocenteGrado(docenteGrado.IdDocenteGrado))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        #region Datos
        private List<ConsultarGradoResult> ConsultarGrado()
        {
            var grados = ObjGrado.ConsultarGrado();
            return grados;
        }
        private List<ConsultarDocenteResult> ConsultarDocente()
        {
            var docentes = ObjDocente.ConsultarDocente();
            return docentes;
        }

        #endregion
    }
}