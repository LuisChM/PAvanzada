using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsTipoIdentificacion
	{
		public List<ConsultarTipoIdentificacionResult> ConsultarTipoIdentificacion()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarTipoIdentificacionResult> datos = db.ConsultarTipoIdentificacion().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaTipoIdentificacionResult ConsultaTipoIdentificacion(int IdTipoIdentificacion)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaTipoIdentificacion(IdTipoIdentificacion).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminaTipoIdentificacion(int IdTipoIdentificacion)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaTipoIdentificacion(IdTipoIdentificacion);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarTipoIdentificacion(int IdTipoIdentificacion, string Descripcion, string Telefono, string Encargado, string Direccion, char Provincia, string Canton, string Distrito, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarTipoIdentificacion(IdTipoIdentificacion, Descripcion, Telefono, Encargado, Direccion, Provincia, Canton, Distrito, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarTipoIdentificacion(string Descripcion, string Telefono, string Encargado, string Direccion, char Provincia, string Canton, string Distrito, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarTipoIdentificacion(Descripcion, Telefono, Encargado, Direccion, Provincia, Canton, Distrito, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

	}
}
