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
                var datos = ObjUsuario.ValidaUsuario(login.Correo, ClaveEncriptada);

                if (datos == null)
                {
                    return View(login);
                }
                else
                {
                    //Roles del  Usuario
                    var ListaRoles = ObjUsuario.ConsultarRolesUsuario(datos.IdUsuario);

                    var roles = String.Join(",", ListaRoles.Select(x => x.Rol));

                    Session["Identificacion"] = datos.Identificacion.ToString();
                    Session["IdInstitucion"] = datos.IdInstitucion.ToString();
                    Session["IdUsuario"] = datos.IdUsuario.ToString();
                    //FormsAuthentication.SetAuthCookie(datos.Nombre + " " + datos.Apellido1 + " " +  datos.Apellido2, login.Recordarme);

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, login.Correo, DateTime.Now, DateTime.Now.AddMinutes(30), login.Recordarme, roles, FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                    if (ticket.IsPersistent)
                    {
                        cookie.Expires = ticket.Expiration;
                    }
                    Response.Cookies.Add(cookie);
                    Session["Identificacion"] = datos.Identificacion;
                    //if (Request.Browser.IsMobileDevice)
                    //{
                    //    return RedirectToAction("Index", "Carnet");
                    //}
                    //else
                    //{
                        return RedirectToAction("Index", "Home");
                    //}


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