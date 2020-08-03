using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsUsuario
	{
		public List<ConsultarUsuarioResult> ConsultarUsuario()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarUsuarioResult> datos = db.ConsultarUsuario().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaUsuarioResult ConsultaUsuario(int IdUsuario)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaUsuario(IdUsuario).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminarUsuario(int IdUsuario)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaUsuario(IdUsuario);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarUsuario(int IdUsuario, int IdInstitucion, int IdTipoIdentificacion, string Identificacion, string Nombre, string Apellido1, string Apellido2, string Clave, string Telefono, string Direccion, string Correo, DateTime FechaNacimiento, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarUsuario(IdUsuario, IdInstitucion, IdTipoIdentificacion, Identificacion, Nombre, Apellido1, Apellido2, Clave, Telefono, Direccion, Correo, FechaNacimiento, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarUsuario(int IdInstitucion, int IdTipoIdentificacion, string Identificacion, string Nombre, string Apellido1, string Apellido2, string Clave, string Telefono, string Direccion, string Correo, DateTime FechaNacimiento, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarUsuario(IdInstitucion, IdTipoIdentificacion, Identificacion, Nombre, Apellido1, Apellido2, Clave, Telefono, Direccion, Correo, FechaNacimiento, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public ValidaUsuarioResult ValidaUsuario(string Correo, string Clave)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				ValidaUsuarioResult dato = db.ValidaUsuario(Correo, Clave).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

	}
}
