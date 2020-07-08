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
    public class RolController : Controller
    {

        clsRol ObjRol = new clsRol();
        // GET: Rol

        public ActionResult Index()
        {
            try
            {
                var datos = ObjRol.ConsultarRol();

                List<Rol> ListaRols = new List<Rol>();

                foreach (var item in datos)
                {
                    Rol rol = new Rol();
                    rol.IdRol = item.IdRol;
                    rol.Descripcion = item.Descripcion;
                    rol.Estado = item.Estado;

                    ListaRols.Add(rol);
                }
                return View(ListaRols);
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
                var dato = ObjRol.ConsultaRol(Convert.ToInt32(id));

                Rol rol = new Rol();
                rol.IdRol = dato.IdRol;
                rol.Descripcion = dato.Descripcion;
                rol.Estado = dato.Estado;
                return View(rol);
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
                var dato = ObjRol.ConsultaRol(Convert.ToInt32(id));

                Rol rol = new Rol();
                rol.IdRol = dato.IdRol;
                rol.Descripcion = dato.Descripcion;
                rol.Estado = dato.Estado;
                return View(rol);
            }

        }
        [HttpPost]
        public ActionResult Editar(Rol rol)
        {
            try
            {
                if (ObjRol.ActualizarRol(rol.IdRol, rol.Descripcion, rol.Estado))
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
        public ActionResult Crear(Rol rol)
        {
            try
            {
                if (ObjRol.AgregarRol(rol.Descripcion, rol.Estado))
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
                var dato = ObjRol.ConsultaRol(Convert.ToInt32(id));

                Rol rol = new Rol();
                rol.IdRol = dato.IdRol;
                rol.Descripcion = dato.Descripcion;
                rol.Estado = dato.Estado;
                return View(rol);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(Rol rol)
        {
            if (ObjRol.EliminarRol(rol.IdRol))
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