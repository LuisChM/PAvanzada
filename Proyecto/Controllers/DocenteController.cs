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
    public class DocenteController : Controller
    {

        clsDocente ObjDocente = new clsDocente();
        clsInstitucion ObjInstitucion = new clsInstitucion();
        clsMateria ObjMateria = new clsMateria();
        clsUsuario ObjUsuario = new clsUsuario();


        // GET: Docente

        public ActionResult Index()
        {
            try
            {
                var datos = ObjDocente.ConsultarDocente();

                List<Docente> ListaDocentes = new List<Docente>();

                foreach (var item in datos)
                {
                    Docente Docente = new Docente();
                    Docente.IdDocente = item.IdDocente;
                    Docente.IdInstitucion = item.IdInstitucion;
                    Docente.IdUsuario = item.IdUsuario;
                    Docente.IdMateria = item.IdMateria;
                    Docente.Estado = item.Estado;

                    ListaDocentes.Add(Docente);
                }
                return View(ListaDocentes);
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
                var dato = ObjDocente.ConsultaDocente(Convert.ToInt32(id));

                Docente Docente = new Docente();
                Docente.IdDocente = dato.IdDocente;
                Docente.IdInstitucion = dato.IdInstitucion;
                Docente.IdUsuario = dato.IdUsuario;
                Docente.IdMateria = dato.IdMateria;
                Docente.Estado = dato.Estado;

                ViewBag.Institucion = ConsultarInstitucion();
                ViewBag.Usuario = ConsultarUsuario();
                ViewBag.Materia = ConsultarMateria();

                return View(Docente);
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
                var dato = ObjDocente.ConsultaDocente(Convert.ToInt32(id));

                Docente Docente = new Docente();
                Docente.IdDocente = dato.IdDocente;
                Docente.IdInstitucion = dato.IdInstitucion;
                Docente.IdUsuario = dato.IdUsuario;
                Docente.IdMateria = dato.IdMateria;
                Docente.Estado = dato.Estado;

                ViewBag.Institucion = ConsultarInstitucion();
                ViewBag.Usuario = ConsultarUsuario();
                ViewBag.Materia = ConsultarMateria();

                return View(Docente);
            }

        }
        [HttpPost]
        public ActionResult Editar(Docente Docente)
        {
            try
            {
                if (ObjDocente.ActualizarDocente(Docente.IdDocente, Docente.IdInstitucion, Docente.IdUsuario, Docente.IdMateria, Docente.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Institucion = ConsultarInstitucion();
                    ViewBag.Usuario = ConsultarUsuario();
                    ViewBag.Materia = ConsultarMateria();

                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Institucion = ConsultarInstitucion();
                ViewBag.Usuario = ConsultarUsuario();
                ViewBag.Materia = ConsultarMateria();

                return View();
                throw;
            }


        }
        public ActionResult Crear()
        {
            ViewBag.Institucion = ConsultarInstitucion();
            ViewBag.Usuario = ConsultarUsuario();
            ViewBag.Materia = ConsultarMateria();

            return View();

        }
        [HttpPost]
        public ActionResult Crear(Docente Docente)
        {
            try
            {
                if (ObjDocente.AgregarDocente(Docente.IdInstitucion, Docente.IdUsuario, Docente.IdMateria, Docente.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Institucion = ConsultarInstitucion();
                    ViewBag.Usuario = ConsultarUsuario();
                    ViewBag.Materia = ConsultarMateria();

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
                var dato = ObjDocente.ConsultaDocente(Convert.ToInt32(id));

                Docente Docente = new Docente();
                Docente.IdDocente = dato.IdDocente;
                Docente.IdInstitucion = dato.IdInstitucion;
                Docente.IdUsuario = dato.IdUsuario;
                Docente.IdMateria = dato.IdMateria;
                Docente.Estado = dato.Estado;
                return View(Docente);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(Docente Docente)
        {
            if (ObjDocente.EliminarDocente(Docente.IdDocente))
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
        private List<ConsultarUsuarioResult> ConsultarUsuario()
        {
            var usuarios = ObjUsuario.ConsultarUsuario();
            return usuarios;
        }
        private List<ConsultarMateriaResult> ConsultarMateria()
        {
            var grados = ObjMateria.ConsultarMateria();
            return grados;
        }
        #endregion
    }
}