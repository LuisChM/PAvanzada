using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using DAL;
using Proyecto.Models;
using Proyecto.Tools;

namespace Proyecto.Controllers
{
    public class UsuarioController : Controller
    {

        clsUsuario ObjUsuario = new clsUsuario();
        clsInstitucion ObjInstitucion = new clsInstitucion();
        clsTipoIdentificacion ObjTipoIdentificacion = new clsTipoIdentificacion();


        // GET: Usuario

        public ActionResult Index()
        {
            try
            {
                var datos = ObjUsuario.ConsultarUsuario();

                List<Usuario> ListaUsuarios = new List<Usuario>();

                foreach (var item in datos)
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = item.IdUsuario;
                    usuario.IdInstitucion = item.IdInstitucion;
                    usuario.IdTipoIdentificacion = item.IdTipoIdentificacion;
                    usuario.Identificacion = item.Identificacion;
                    usuario.Nombre = item.Nombre;
                    usuario.Apellido1 = item.Apellido1;
                    usuario.Apellido2 = item.Apellido2;
                    usuario.Clave = item.Clave;
                    usuario.Telefono = item.Telefono;
                    usuario.Direccion = item.Direccion;
                    usuario.Correo = item.Correo;
                    usuario.FechaNacimiento = item.FechaNacimiento;
                    usuario.Estado = item.Estado;

                    ListaUsuarios.Add(usuario);
                }
                return View(ListaUsuarios);
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
                var dato = ObjUsuario.ConsultaUsuario(Convert.ToInt32(id));

                Usuario usuario = new Usuario();
                usuario.IdUsuario = dato.IdUsuario;
                usuario.IdInstitucion = dato.IdInstitucion;
                usuario.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                usuario.Identificacion = dato.Identificacion;
                usuario.Nombre = dato.Nombre;
                usuario.Apellido1 = dato.Apellido1;
                usuario.Apellido2 = dato.Apellido2;
                usuario.Clave = dato.Clave;
                usuario.Telefono = dato.Telefono;
                usuario.Direccion = dato.Direccion;
                usuario.Correo = dato.Correo;
                usuario.FechaNacimiento = dato.FechaNacimiento;
                usuario.Estado = dato.Estado;

                ViewBag.TipoIdentificacion = ConsultarTipoIdentificacion();
                ViewBag.Institucion = ConsultarInstitucion();

                return View(usuario);
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
                var dato = ObjUsuario.ConsultaUsuario(Convert.ToInt32(id));


                Usuario usuario = new Usuario();
                usuario.IdUsuario = dato.IdUsuario;
                usuario.IdInstitucion = dato.IdInstitucion;
                usuario.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                usuario.Identificacion = dato.Identificacion;
                usuario.Nombre = dato.Nombre;
                usuario.Apellido1 = dato.Apellido1;
                usuario.Apellido2 = dato.Apellido2;
                usuario.Clave = dato.Clave;
                usuario.Telefono = dato.Telefono;
                usuario.Direccion = dato.Direccion;
                usuario.Correo = dato.Correo;
                usuario.FechaNacimiento = dato.FechaNacimiento;
                usuario.Estado = dato.Estado;

                ViewBag.TipoIdentificacion = ConsultarTipoIdentificacion();
                ViewBag.Institucion = ConsultarInstitucion();

                return View(usuario);
            }

        }
        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            try
            {
                if (ObjUsuario.ActualizarUsuario(usuario.IdUsuario, usuario.IdInstitucion, usuario.IdTipoIdentificacion, usuario.Identificacion, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, usuario.Clave, usuario.Telefono, usuario.Direccion, usuario.Correo, usuario.FechaNacimiento, usuario.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.TipoIdentificacion = ConsultarTipoIdentificacion();
                    ViewBag.Institucion = ConsultarInstitucion();

                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.TipoIdentificacion = ConsultarTipoIdentificacion();
                ViewBag.Institucion = ConsultarInstitucion();

                return View();
                throw;
            }


        }
        public ActionResult Crear()
        {
            ViewBag.TipoIdentificacion = ConsultarTipoIdentificacion();
            ViewBag.Institucion = ConsultarInstitucion();

            return View();

        }
        [HttpPost]
        public ActionResult Crear(Usuario usuario)
        {
            var SecretKey = ConfigurationManager.AppSettings["SecretKey"];
            var ClaveEncriptada = Seguridad.EncryptString(SecretKey, usuario.Clave);

            try
            {
                if (ObjUsuario.AgregarUsuario(usuario.IdInstitucion, usuario.IdTipoIdentificacion, usuario.Identificacion, usuario.Nombre, usuario.Apellido1, usuario.Apellido2, ClaveEncriptada, usuario.Telefono, usuario.Direccion, usuario.Correo, usuario.FechaNacimiento, usuario.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.TipoIdentificacion = ConsultarTipoIdentificacion();
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
                var dato = ObjUsuario.ConsultaUsuario(Convert.ToInt32(id));

                Usuario usuario = new Usuario();
                usuario.IdUsuario = dato.IdUsuario;
                usuario.IdInstitucion = dato.IdInstitucion;
                usuario.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                usuario.Identificacion = dato.Identificacion;
                usuario.Nombre = dato.Nombre;
                usuario.Apellido1 = dato.Apellido1;
                usuario.Apellido2 = dato.Apellido2;
                usuario.Clave = dato.Clave;
                usuario.Telefono = dato.Telefono;
                usuario.Direccion = dato.Direccion;
                usuario.Correo = dato.Correo;
                usuario.FechaNacimiento = dato.FechaNacimiento;
                usuario.Estado = dato.Estado;

                return View(usuario);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(Usuario usuario)
        {
            if (ObjUsuario.EliminarUsuario(usuario.IdUsuario))
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
            var grados = ObjInstitucion.ConsultarInstitucion();
            return grados;
        }
        private List<ConsultarTipoIdentificacionResult> ConsultarTipoIdentificacion()
        {
            var materias = ObjTipoIdentificacion.ConsultarTipoIdentificacion();
            return materias;
        }

        #endregion
    }
}