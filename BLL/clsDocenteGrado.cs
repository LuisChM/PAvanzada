using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsDocenteGrado
	{
		public List<ConsultarDocenteGradoResult> ConsultarDocenteGrado()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarDocenteGradoResult> datos = db.ConsultarDocenteGrado().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaDocenteGradoResult ConsultaDocenteGrado(int IdDocenteGrado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaDocenteGrado(IdDocenteGrado).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminarDocenteGrado(int IdDocenteGrado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaDocenteGrado(IdDocenteGrado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarDocenteGrado(int IdDocenteGrado, int IdDocente, int IdGrado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarDocenteGrado(IdDocenteGrado, IdDocente, IdGrado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarDocenteGrado(int IdDocente, int IdGrado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarDocenteGrado(IdDocente, IdGrado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

	}
}
