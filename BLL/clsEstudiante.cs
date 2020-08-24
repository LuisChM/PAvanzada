using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsEstudiante
	{
		public List<ConsultarEstudianteResult> ConsultarEstudiante()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarEstudianteResult> datos = db.ConsultarEstudiante().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaEstudianteResult ConsultaEstudiante(int IdEstudiante)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaEstudiante(IdEstudiante).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminarEstudiante(int IdEstudiante)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaEstudiante(IdEstudiante);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarEstudiante(int IdEstudiante, int IdInstitucion, int IdUsuario, int IdGrado, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarEstudiante(IdEstudiante, IdInstitucion, IdUsuario, IdGrado, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarEstudiante(int IdInstitucion, int IdUsuario, int IdGrado, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarEstudiante(IdInstitucion, IdUsuario, IdGrado, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
