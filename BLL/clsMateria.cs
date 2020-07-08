using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsMateria
	{
		public List<ConsultarMateriaResult> ConsultarMateria()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarMateriaResult> datos = db.ConsultarMateria().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaMateriaResult ConsultaMateria(int IdMateria)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaMateria(IdMateria).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminarMateria(int IdMateria)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaMateria(IdMateria);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarMateria(int IdMateria, string Descripcion, int? IdInstitucion, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarMateria(IdMateria, Descripcion, IdInstitucion, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarMateria(string Descripcion, int? IdInstitucion, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarMateria(Descripcion, IdInstitucion, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

	}
}
