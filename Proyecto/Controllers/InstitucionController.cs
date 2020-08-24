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
    public class InstitucionController : Controller
    {

        clsInstitucion ObjInstitucion = new clsInstitucion();
        clsConsultas ObjConsulta = new clsConsultas();

        // GET: Institucion
        public ActionResult Index()
        {
            try
            {
                var datos = ObjInstitucion.ConsultarInstitucion();

                List<Institucion> ListaInstitucions = new List<Institucion>();

                foreach (var item in datos)
                {
                    Institucion institucion = new Institucion();
                    institucion.IdInstitucion = item.IdInstitucion;
                    institucion.Descripcion = item.Descripcion;
                    institucion.Telefono = item.Telefono;
                    institucion.Encargado = item.Encargado;
                    institucion.Direccion = item.Direccion;
                    institucion.Provincia = item.Provincia;
                    institucion.Canton = item.Canton;
                    institucion.Distrito = item.Distrito;
                    institucion.Estado = item.Estado;

                    ListaInstitucions.Add(institucion);
                }
                return View(ListaInstitucions);
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
                var dato = ObjInstitucion.ConsultaInstitucion(Convert.ToInt32(id));

                Institucion institucion = new Institucion();
                institucion.IdInstitucion = dato.IdInstitucion;
                institucion.Descripcion = dato.Descripcion;
                institucion.Telefono = dato.Telefono;
                institucion.Encargado = dato.Encargado;
                institucion.Direccion = dato.Direccion;
                institucion.Provincia = dato.Provincia;
                institucion.Canton = dato.Canton;
                institucion.Distrito = dato.Distrito;
                institucion.Estado = dato.Estado;


                ViewBag.Provincias = Provincias();
                ViewBag.Cantones = Cantones(dato.Provincia);
                ViewBag.Distritos = Distritos(dato.Provincia, dato.Canton);
                return View(institucion);
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
                var dato = ObjInstitucion.ConsultaInstitucion(Convert.ToInt32(id));

                Institucion institucion = new Institucion();
                institucion.IdInstitucion = dato.IdInstitucion;
                institucion.Descripcion = dato.Descripcion;
                institucion.Telefono = dato.Telefono;
                institucion.Encargado = dato.Encargado;
                institucion.Direccion = dato.Direccion;
                institucion.Provincia = dato.Provincia;
                institucion.Canton = dato.Canton;
                institucion.Distrito = dato.Distrito;
                institucion.Estado = dato.Estado;


                ViewBag.Provincias = Provincias();
                ViewBag.Cantones = Cantones(dato.Provincia);
                ViewBag.Distritos = Distritos(dato.Provincia, dato.Canton);
                return View(institucion);
            }

        }
        [HttpPost]
        public ActionResult Editar(Institucion institucion)
        {
            try
            {
                if (ObjInstitucion.ActualizarInstitucion(institucion.IdInstitucion, institucion.Descripcion,institucion.Telefono,institucion.Encargado, institucion.Direccion, institucion.Provincia, institucion.Canton, institucion.Distrito, institucion.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Provincias = Provincias();
                    ViewBag.Cantones = Cantones(institucion.Provincia);
                    ViewBag.Distritos = Distritos(institucion.Provincia, institucion.Canton);
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Provincias = Provincias();
                ViewBag.Cantones = Cantones(institucion.Provincia);
                ViewBag.Distritos = Distritos(institucion.Provincia, institucion.Canton);
                return View();
                throw;
            }


        }
        public ActionResult Crear()
        {
            ViewBag.Provincias = Provincias();
            return View();

        }
        [HttpPost]
        public ActionResult Crear(Institucion institucion)
        {
            try
            {
                if (ObjInstitucion.AgregarInstitucion(institucion.Descripcion, institucion.Telefono, institucion.Encargado, institucion.Direccion, institucion.Provincia, institucion.Canton, institucion.Distrito, institucion.Estado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Provincias = Provincias();
                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Provincias = Provincias();
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
                var dato = ObjInstitucion.ConsultaInstitucion(Convert.ToInt32(id));

                Institucion institucion = new Institucion();
                institucion.IdInstitucion = dato.IdInstitucion;
                institucion.Descripcion = dato.Descripcion;
                institucion.Telefono = dato.Telefono;
                institucion.Encargado = dato.Encargado;
                institucion.Direccion = dato.Direccion;
                institucion.Provincia = dato.Provincia;
                institucion.Canton = dato.Canton;
                institucion.Distrito = dato.Distrito;
                institucion.Estado = dato.Estado;

                return View(institucion);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(Institucion institucion)
        {
            if (ObjInstitucion.EliminaInstitucion(institucion.IdInstitucion))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        #region Datos
        private List<ProvinciasResult> Provincias()
        {
            var provincias = ObjConsulta.ConsultarProvincias();
            return provincias;
        }
        private List<CantonesResult> Cantones(char Provincia)
        {
            var cantones = ObjConsulta.ConsultarCantones(Provincia);
            return cantones;
        }
        private List<DistritosResult> Distritos(char Provincia, string Canton)
        {
            var distritos = ObjConsulta.ConsultarDistritos(Provincia, Canton);
            return distritos;
        }
        #endregion

        [HttpPost]
        public JsonResult CargaCantones(char provincia)
        {
            List<CantonesResult> cantones = ObjConsulta.ConsultarCantones(provincia);
            return Json(cantones, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult CargaDistritos(char provincia, string canton)
        {
            List<DistritosResult> distritos = ObjConsulta.ConsultarDistritos(provincia, canton);
            return Json(distritos, JsonRequestBehavior.AllowGet);
        }

    }
}