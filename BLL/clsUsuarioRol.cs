using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsUsuarioRol
	{
		public List<ConsultarUsuarioRolResult> ConsultarUsuarioRol()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarUsuarioRolResult> datos = db.ConsultarUsuarioRol().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaUsuarioRolResult ConsultaUsuarioRol(int IdUsuarioRol)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaUsuarioRol(IdUsuarioRol).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminarUsuarioRol(int IdUsuarioRol)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaUsuarioRol(IdUsuarioRol);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarUsuarioRol(int IdUsuarioRol, int IdUsuario, int IdRol)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarUsuarioRol(IdUsuarioRol, IdUsuario, IdRol);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarUsuarioRol(int IdUsuario, int IdRol)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarUsuarioRol(IdUsuario, IdRol);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

	}
}
