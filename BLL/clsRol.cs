using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsRol
	{
		public List<ConsultarRolResult> ConsultarRol()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarRolResult> datos = db.ConsultarRol().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaRolResult ConsultaRol(int IdRol)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaRol(IdRol).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminarRol(int IdRol)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaRol(IdRol);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarRol(int IdRol, string Descripcion, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarRol(IdRol, Descripcion, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarRol(string Descripcion, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarRol(Descripcion, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

	}
}
