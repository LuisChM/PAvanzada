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
    public class TipoOperacionController : Controller
    {

        clsTipoOperacion ObjTipoOperacion = new clsTipoOperacion();
        // GET: TipoOperacion

        public ActionResult Index()
        {
            try
            {
                var datos = ObjTipoOperacion.ConsultarTipoOperacion();

                List<TipoOperacion> ListaTipoOperacions = new List<TipoOperacion>();

                foreach (var item in datos)
                {
                    TipoOperacion tipoOperacion = new TipoOperacion();
                    tipoOperacion.IdTipoOperacion = item.IdTipoOperacion;
                    tipoOperacion.Descripcion = item.Descripcion;
                    tipoOperacion.Estado = item.Estado;

                    ListaTipoOperacions.Add(tipoOperacion);
                }
                return View(ListaTipoOperacions);
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
                var dato = ObjTipoOperacion.ConsultaTipoOperacion(Convert.ToInt32(id));

                TipoOperacion tipoOperacion = new TipoOperacion();
                tipoOperacion.IdTipoOperacion = dato.IdTipoOperacion;
                tipoOperacion.Descripcion = dato.Descripcion;
                tipoOperacion.Estado = dato.Estado;
                return View(tipoOperacion);
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
                var dato = ObjTipoOperacion.ConsultaTipoOperacion(Convert.ToInt32(id));

                TipoOperacion tipoOperacion = new TipoOperacion();
                tipoOperacion.IdTipoOperacion = dato.IdTipoOperacion;
                tipoOperacion.Descripcion = dato.Descripcion;
                tipoOperacion.Estado = dato.Estado;
                return View(tipoOperacion);
            }

        }
        [HttpPost]
        public ActionResult Editar(TipoOperacion tipoOperacion)
        {
            try
            {
                if (ObjTipoOperacion.ActualizarTipoOperacion(tipoOperacion.IdTipoOperacion, tipoOperacion.Descripcion, tipoOperacion.Estado))
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
        public ActionResult Crear(TipoOperacion tipoOperacion)
        {
            try
            {
                if (ObjTipoOperacion.AgregarTipoOperacion(tipoOperacion.Descripcion, tipoOperacion.Estado))
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
                var dato = ObjTipoOperacion.ConsultaTipoOperacion(Convert.ToInt32(id));

                TipoOperacion tipoOperacion = new TipoOperacion();
                tipoOperacion.IdTipoOperacion = dato.IdTipoOperacion;
                tipoOperacion.Descripcion = dato.Descripcion;
                tipoOperacion.Estado = dato.Estado;
                return View(tipoOperacion);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(TipoOperacion tipoOperacion)
        {
            if (ObjTipoOperacion.EliminarTipoOperacion(tipoOperacion.IdTipoOperacion))
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