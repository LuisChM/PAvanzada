using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser : AuthorizeAttribute
    {
        private Usuario oUsuario;
        private PAvanzadaEntities db = new PAvanzadaEntities();
        private int IdRol;

        public AuthorizeUser(int IdRol = 0)
        {
            this.IdRol = IdRol;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            String nombreRol = "";
            try
            {
                oUsuario = (Usuario)HttpContext.Current.Session["User"];
                var lstMisRoles = from m in db.UsuarioRol
                                        where m.IdUsuario == oUsuario.IdUsuario
                                            && m.IdRol == IdRol
                                        select m;


                if (lstMisRoles.ToList().Count() == 0)
                {
                    var oOperacion = db.Rol.Find(IdRol);
                    int? idModulo = oOperacion.idModulo;
                    nombreOperacion = getNombreDeOperacion(idOperacion);
                    nombreModulo = getNombreDelModulo(idModulo);
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=");
                }
            }
            catch (Exception ex)
            {
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?operacion=" + nombreOperacion + "&modulo=" + nombreModulo + "&msjeErrorExcepcion=" + ex.Message);
            }
        }

        public string getNombreDeOperacion(int idOperacion)
        {
            var ope = from op in db.operaciones
                      where op.id == idOperacion
                      select op.nombre;
            String nombreOperacion;
            try
            {
                nombreOperacion = ope.First();
            }
            catch (Exception)
            {
                nombreOperacion = "";
            }
            return nombreOperacion;
        }

        public string getNombreDelModulo(int? idModulo)
        {
            var modulo = from m in db.modulo
                         where m.id == idModulo
                         select m.nombre;
            String nombreModulo;
            try
            {
                nombreModulo = modulo.First();
            }
            catch (Exception)
            {
                nombreModulo = "";
            }
            return nombreModulo;
        }

    }
}