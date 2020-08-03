using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsCalificacion
	{
		public List<ConsultarCalificacionResult> ConsultarCalificacion()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarCalificacionResult> datos = db.ConsultarCalificacion().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaCalificacionResult ConsultaCalificacion(int IdCalificacion)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaCalificacion(IdCalificacion).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminarCalificacion(int IdCalificacion)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaCalificacion(IdCalificacion);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarCalificacion(int IdCalificacion, int IdTipoOperacion, int IdEstudiante, int IdDocente, int IdMateria, decimal Nota, DateTime Fecha )
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarCalificacion(IdCalificacion, IdTipoOperacion, IdEstudiante, IdDocente, IdMateria, Nota, Fecha);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarCalificacion(int IdTipoOperacion, int IdEstudiante, int IdDocente, int IdMateria, decimal Nota, DateTime Fecha)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarCalificacion(IdTipoOperacion, IdEstudiante, IdDocente, IdMateria, Nota, Fecha);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

	}
}
