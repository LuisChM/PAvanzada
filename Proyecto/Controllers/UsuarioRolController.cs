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
    
    public class UsuarioRolController : Controller
    {

        clsUsuarioRol ObjUsuarioRol = new clsUsuarioRol();
        clsUsuario ObjUsuario = new clsUsuario();
        clsRol ObjRol = new clsRol();


        // GET: UsuarioRol

        public ActionResult Index()
        {
            try
            {
                var datos = ObjUsuarioRol.ConsultarUsuarioRol();

                List<UsuarioRol> ListaUsuarioRols = new List<UsuarioRol>();

                foreach (var item in datos)
                {
                    UsuarioRol usuarioRol = new UsuarioRol();
                    usuarioRol.IdUsuarioRol = item.IdUsuarioRol;
                    usuarioRol.IdUsuario = item.IdUsuario;
                    usuarioRol.IdRol = item.IdRol;

                    ListaUsuarioRols.Add(usuarioRol);
                }
                return View(ListaUsuarioRols);
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
                var dato = ObjUsuarioRol.ConsultaUsuarioRol(Convert.ToInt32(id));

                UsuarioRol usuarioRol = new UsuarioRol();
                usuarioRol.IdUsuarioRol = dato.IdUsuarioRol;
                usuarioRol.IdUsuario = dato.IdUsuario;
                usuarioRol.IdRol = dato.IdRol;

                ViewBag.Usuario = ConsultarUsuario();
                ViewBag.Rol = ConsultarRol();

                return View(usuarioRol);
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
                var dato = ObjUsuarioRol.ConsultaUsuarioRol(Convert.ToInt32(id));

                UsuarioRol usuarioRol = new UsuarioRol();
                usuarioRol.IdUsuarioRol = dato.IdUsuarioRol;
                usuarioRol.IdUsuario = dato.IdUsuario;
                usuarioRol.IdRol = dato.IdRol;

                ViewBag.Usuario = ConsultarUsuario();
                ViewBag.Rol = ConsultarRol();

                return View(usuarioRol);
            }

        }
        [HttpPost]
        public ActionResult Editar(UsuarioRol usuarioRol)
        {
            try
            {
                if (ObjUsuarioRol.ActualizarUsuarioRol(usuarioRol.IdUsuarioRol, usuarioRol.IdUsuario, usuarioRol.IdRol))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Usuario = ConsultarUsuario();
                    ViewBag.Rol = ConsultarRol();

                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Usuario = ConsultarUsuario();
                ViewBag.Rol = ConsultarRol();

                return View();
                throw;
            }


        }
        public ActionResult Crear()
        {
            ViewBag.Usuario = ConsultarUsuario();
            ViewBag.Rol = ConsultarRol();

            return View();

        }
        [HttpPost]
        public ActionResult Crear(UsuarioRol usuarioRol)
        {
            try
            {
                if (ObjUsuarioRol.AgregarUsuarioRol(usuarioRol.IdUsuario, usuarioRol.IdRol))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Usuario = ConsultarUsuario();
                    ViewBag.Rol = ConsultarRol();

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
                var dato = ObjUsuarioRol.ConsultaUsuarioRol(Convert.ToInt32(id));

                UsuarioRol usuarioRol = new UsuarioRol();
                usuarioRol.IdUsuarioRol = dato.IdUsuarioRol;
                usuarioRol.IdUsuario = dato.IdUsuario;
                usuarioRol.IdRol = dato.IdRol;

                return View(usuarioRol);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(UsuarioRol usuarioRol)
        {
            if (ObjUsuarioRol.EliminarUsuarioRol(usuarioRol.IdUsuarioRol))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        #region Datos
        private List<ConsultarUsuarioResult> ConsultarUsuario()
        {
            var grados = ObjUsuario.ConsultarUsuario();
            return grados;
        }
        private List<ConsultarRolResult> ConsultarRol()
        {
            var materias = ObjRol.ConsultarRol();
            return materias;
        }

        #endregion
    }
}