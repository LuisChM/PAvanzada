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
    public class MateriaGradoController : Controller
    {

        clsMateriaGrado ObjMateriaGrado = new clsMateriaGrado();
        clsMateria ObjMateria = new clsMateria();
        clsGrado ObjGrado = new clsGrado();


        // GET: MateriaGrado

        public ActionResult Index()
        {
            try
            {
                var datos = ObjMateriaGrado.ConsultarMateriaGrado();

                List<MateriaGrado> ListaMateriaGrados = new List<MateriaGrado>();

                foreach (var item in datos)
                {
                    MateriaGrado materiaGrado = new MateriaGrado();
                    materiaGrado.IdMateriaGrado = item.IdMateriaGrado;
                    materiaGrado.IdMateria = item.IdMateria;
                    materiaGrado.IdGrado = item.IdGrado;

                    ListaMateriaGrados.Add(materiaGrado);
                }
                return View(ListaMateriaGrados);
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
                var dato = ObjMateriaGrado.ConsultaMateriaGrado(Convert.ToInt32(id));

                MateriaGrado materiaGrado = new MateriaGrado();
                materiaGrado.IdMateriaGrado = dato.IdMateriaGrado;
                materiaGrado.IdMateria = dato.IdMateria;
                materiaGrado.IdGrado = dato.IdGrado;

                ViewBag.Materia = ConsultarMateria();
                ViewBag.Grado = ConsultarGrado();

                return View(materiaGrado);
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
                var dato = ObjMateriaGrado.ConsultaMateriaGrado(Convert.ToInt32(id));

                MateriaGrado materiaGrado = new MateriaGrado();
                materiaGrado.IdMateriaGrado = dato.IdMateriaGrado;
                materiaGrado.IdMateria = dato.IdMateria;
                materiaGrado.IdGrado = dato.IdGrado;

                ViewBag.Materia = ConsultarMateria();
                ViewBag.Grado = ConsultarGrado();

                return View(materiaGrado);
            }

        }
        [HttpPost]
        public ActionResult Editar(MateriaGrado materiaGrado)
        {
            try
            {
                if (ObjMateriaGrado.ActualizarMateriaGrado(materiaGrado.IdMateriaGrado, materiaGrado.IdMateria, materiaGrado.IdGrado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Materia = ConsultarMateria();
                    ViewBag.Grado = ConsultarGrado();

                    return View();
                }
            }
            catch (Exception)
            {
                ViewBag.Materia = ConsultarMateria();
                ViewBag.Grado = ConsultarGrado();

                return View();
                throw;
            }


        }
        public ActionResult Crear()
        {
            ViewBag.Materia = ConsultarMateria();
            ViewBag.Grado = ConsultarGrado();

            return View();

        }
        [HttpPost]
        public ActionResult Crear(MateriaGrado materiaGrado)
        {
            try
            {
                if (ObjMateriaGrado.AgregarMateriaGrado(materiaGrado.IdMateria, materiaGrado.IdGrado))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Materia = ConsultarMateria();
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
                var dato = ObjMateriaGrado.ConsultaMateriaGrado(Convert.ToInt32(id));

                MateriaGrado materiaGrado = new MateriaGrado();
                materiaGrado.IdMateriaGrado = dato.IdMateriaGrado;
                materiaGrado.IdMateria = dato.IdMateria;
                materiaGrado.IdGrado = dato.IdGrado;

                return View(materiaGrado);
            }

        }
        [HttpPost]
        public ActionResult Eliminar(MateriaGrado materiaGrado)
        {
            if (ObjMateriaGrado.EliminarMateriaGrado(materiaGrado.IdMateriaGrado))
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
        private List<ConsultarMateriaResult> ConsultarMateria()
        {
            var materias = ObjMateria.ConsultarMateria();
            return materias;
        }

        #endregion
    }
}