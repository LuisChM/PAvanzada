using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Proyecto.Models;
using System.Web.Security;
using System.Configuration;
using Proyecto.Tools;

namespace Proyecto.Controllers
{
    public class LoginController : Controller
    {
        clsUsuario ObjUsuario = new clsUsuario();

        [AllowAnonymous]
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Login login)
        {

            var SecretKey = ConfigurationManager.AppSettings["SecretKey"];
            if (ModelState.IsValid)
            {
                var ClaveEncriptada = Seguridad.EncryptString(SecretKey, login.Clave);
                //var ClaveDesencriptada = Seguridad.DecryptString(SecretKey, ClaveEncriptada);
                var dato = ObjUsuario.ValidaUsuario(login.Correo, ClaveEncriptada);

                if (dato == null)
                {
                    return View(login);
                }
                else
                {
                    Session["Identificacion"] = dato.Identificacion.ToString();
                    FormsAuthentication.SetAuthCookie(dato.Nombre, login.Recordarme);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View(login);
            }
        }
        /// <summary>
        /// ESte Metodo sirve para salir del sistema
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Salir()
        {
            Session.Remove("Identificacion");
            Session.RemoveAll();
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Session.Clear();
            FormsAuthentication.SignOut();
            Session.Abandon();
            Response.Cache.SetNoServerCaching();
            Request.Cookies.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}