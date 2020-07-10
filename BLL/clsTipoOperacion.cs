using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsTipoOperacion
	{
		public List<ConsultarTipoOperacionResult> ConsultarTipoOperacion()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarTipoOperacionResult> datos = db.ConsultarTipoOperacion().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaTipoOperacionResult ConsultaTipoOperacion(int IdTipoOperacion)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaTipoOperacion(IdTipoOperacion).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminarTipoOperacion(int IdTipoOperacion)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaTipoOperacion(IdTipoOperacion);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarTipoOperacion(int IdTipoOperacion, string Descripcion, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarTipoOperacion(IdTipoOperacion, Descripcion, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarTipoOperacion(string Descripcion, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarTipoOperacion(Descripcion, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

	}
}
