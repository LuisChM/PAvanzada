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
    public class GradoController : Controller
    {

        clsGrado ObjGrado = new clsGrado();
        // GET: Grado

        public ActionResult Index()
        {
            try
            {
                var datos = ObjGrado.ConsultarGrado();

                List<Grado> ListaGrados = new List<Grado>();

                foreach (var item in datos)
                {
                    Grado grado = new Grado();
                    grado.IdGrado = item.IdGrado;
                    grado.Descripcion = item.Descripcion;
                   grado.Estado = item.Estado;

                    ListaGrados.Add(grado);
                }
                return View(ListaGrados);
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
                var dato = ObjGrado.ConsultaGrado(Convert.ToInt32(id));

                Grado grado = new Grado();
                grado.IdGrado = dato.IdGrado;
                grado.Descripcion = dato.Descripcion;
                grado.Estado = dato.Estado;
                return View(grado);
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
                var dato = ObjGrado.ConsultaGrado(Convert.ToInt32(id));

                Grado grado = new Grado();
                grado.IdGrado = dato.IdGrado;
                grado.Descripcion = dato.Descripcion;
                grado.Estado = dato.Estado;
                return View(grado);
            }

        }
        [HttpPost]
        public ActionResult Editar(Grado grado)
        {
            try
            {
                if (ObjGrado.ActualizarGrado(grado.IdGrado, grado.Descripcion, grado.Estado))
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
        public ActionResult Crear(Grado grado)
        {
            try
            {
                if (ObjGrado.AgregarGrado(grado.Descripcion, grado.Estado))
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
                var dato = ObjGrado.ConsultaGrado(Convert.ToInt32(id));

                Grado grado = new Grado();
                grado.IdGrado = dato.IdGrado;
                grado.Descripcion = dato.Descripcion;
                grado.Estado = dato.Estado;
                return View(grado);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(Grado grado)
        {
            if (ObjGrado.EliminarGrado(grado.IdGrado))
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