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
    public class TipoIdentificacionController : Controller
    {

        clsTipoIdentificacion ObjTipoIdentificacion = new clsTipoIdentificacion();
        clsConsultas ObjConsulta = new clsConsultas();
        // GET: TipoIdentificacion

        public ActionResult Index()
        {
            try
            {
                var datos = ObjTipoIdentificacion.ConsultarTipoIdentificacion();

                List<TipoIdentificacion> ListaTipoIdentificacions = new List<TipoIdentificacion>();

                foreach (var item in datos)
                {
                    TipoIdentificacion tipoIdentificacion = new TipoIdentificacion();
                    tipoIdentificacion.IdTipoIdentificacion = item.IdTipoIdentificacion;
                    tipoIdentificacion.Descripcion = item.Descripcion;
                    tipoIdentificacion.Estado = item.Estado;

                    ListaTipoIdentificacions.Add(tipoIdentificacion);
                }
                return View(ListaTipoIdentificacions);
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
                var dato = ObjTipoIdentificacion.ConsultaTipoIdentificacion(Convert.ToInt32(id));

                TipoIdentificacion tipoIdentificacion = new TipoIdentificacion();
                tipoIdentificacion.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                tipoIdentificacion.Descripcion = dato.Descripcion;
                tipoIdentificacion.Estado = dato.Estado;
                return View(tipoIdentificacion);
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
                var dato = ObjTipoIdentificacion.ConsultaTipoIdentificacion(Convert.ToInt32(id));

                TipoIdentificacion tipoIdentificacion = new TipoIdentificacion();
                tipoIdentificacion.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                tipoIdentificacion.Descripcion = dato.Descripcion;
                tipoIdentificacion.Estado = dato.Estado;
                return View(tipoIdentificacion);
            }

        }
        [HttpPost]
        public ActionResult Editar(TipoIdentificacion tipoIdentificacion)
        {
            try
            {
                if (ObjTipoIdentificacion.ActualizarTipoIdentificacion(tipoIdentificacion.IdTipoIdentificacion, tipoIdentificacion.Descripcion, tipoIdentificacion.Estado))
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
        public ActionResult Crear(TipoIdentificacion tipoIdentificacion)
        {
            try
            {
                if (ObjTipoIdentificacion.AgregarTipoIdentificacion(tipoIdentificacion.Descripcion, tipoIdentificacion.Estado))
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
                var dato = ObjTipoIdentificacion.ConsultaTipoIdentificacion(Convert.ToInt32(id));

                TipoIdentificacion tipoIdentificacion = new TipoIdentificacion();
                tipoIdentificacion.IdTipoIdentificacion = dato.IdTipoIdentificacion;
                tipoIdentificacion.Descripcion = dato.Descripcion;
                tipoIdentificacion.Estado = dato.Estado;
                return View(tipoIdentificacion);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(TipoIdentificacion tipoIdentificacion)
        {
            if (ObjTipoIdentificacion.EliminarTipoIdentificacion(tipoIdentificacion.IdTipoIdentificacion))
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