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
    public class EstudianteController : Controller
    {

        clsEstudiante ObjEstudiante = new clsEstudiante();
        clsInstitucion ObjInstitucion = new clsInstitucion();
        clsGrado ObjGrado = new clsGrado();
        clsUsuario ObjUsuario = new clsUsuario();


        // GET: Estudiante

        public ActionResult Index()
        {
            try
            {
                var datos = ObjEstudiante.ConsultarEstudiante();

                List<Estudiante> ListaEstudiantes = new List<Estudiante>();

                foreach (var item in datos)
                {
                    Estudiante Estudiante = new Estudiante();
                    Estudiante.IdEstudiante = item.IdEstudiante;
                    Estudiante.IdInstitucion = item.IdInstitucion;
                    Estudiante.IdUsuario = item.IdUsuario;
                    Estudiante.IdGrado = item.IdGrado;
                    Estudiante.Estado = item.Estado;

                    ListaEstudiantes.Add(Estudiante);
                }
                return View(ListaEstudiantes);
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
                var dato = ObjEstudiante.ConsultaEstudiante(Convert.ToInt32(id));

                Estudiante Estudiante = new Estudiante();
                Estudiante.IdEstudiante = dato.IdEstudiante;
                Estudiante.IdInstitucion = dato.IdInstitucion;
                Estudiante.IdUsuario = dato.IdUsuario;
                Estudiante.IdGrado = dato.IdGrado;
                Estudiante.Estado = dato.Estado;

                ViewBag.Institucion = ConsultarInstitucion();
                ViewBag.Usuario = ConsultarUsuario();
                ViewBag.Grado = ConsultarGrado();

                return View(Estudiante);
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
                var dato = ObjEstudiante.ConsultaEstudiante(Convert.ToInt32(id));

                Estudiante Estudiante = new Estudiante();
                Estudiante.IdEstudiante = dato.IdEstudiante;
                Estudiante.IdInstitucion = dato.IdInstitucion;
                Estudiante.IdUsuario = dato.IdUsuario;
                Estudiante.IdGrado = dato.IdGrado;
                Estudiante.Estado = dato.Estado;

                ViewBag.Institucion = ConsultarInstitucion();
                ViewBag.Usuario = ConsultarUsuario();
                ViewBag.Grado = ConsultarGrado();

                return View(Estudiante);
            }

        }
        [HttpPost]
        public ActionResult Editar(Estudiante Estudiante)
        {
            try
            {
                if (ObjEstudiante.ActualizarEstudiante(Estudiante.IdEstudiante, Estudiante.IdInstitucion, Estudiante.IdUsuario, Estudiante.IdGrado, Estudiante.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Institucion = ConsultarInstitucion();
                    ViewBag.Usuario = ConsultarUsuario();
                    ViewBag.Grado = ConsultarGrado();

                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Institucion = ConsultarInstitucion();
                ViewBag.Usuario = ConsultarUsuario();
                ViewBag.Grado = ConsultarGrado();

                return View();
                throw;
            }


        }
        public ActionResult Crear()
        {
            ViewBag.Institucion = ConsultarInstitucion();
            ViewBag.Usuario = ConsultarUsuario();
            ViewBag.Grado = ConsultarGrado();

            return View();

        }
        [HttpPost]
        public ActionResult Crear(Estudiante Estudiante)
        {
            try
            {
                if (ObjEstudiante.AgregarEstudiante(Estudiante.IdInstitucion, Estudiante.IdUsuario, Estudiante.IdGrado, Estudiante.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Institucion = ConsultarInstitucion();
                    ViewBag.Usuario = ConsultarUsuario();
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
                var dato = ObjEstudiante.ConsultaEstudiante(Convert.ToInt32(id));

                Estudiante Estudiante = new Estudiante();
                Estudiante.IdEstudiante = dato.IdEstudiante;
                Estudiante.IdInstitucion = dato.IdInstitucion;
                Estudiante.IdUsuario = dato.IdUsuario;
                Estudiante.IdGrado = dato.IdGrado;
                Estudiante.Estado = dato.Estado;
                return View(Estudiante);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(Estudiante Estudiante)
        {
            if (ObjEstudiante.EliminarEstudiante(Estudiante.IdEstudiante))
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
        private List<ConsultarGradoResult> ConsultarGrado()
        {
            var grados = ObjGrado.ConsultarGrado();
            return grados;
        }
        #endregion
    }
}