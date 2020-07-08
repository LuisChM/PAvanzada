using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsGrado
	{
		public List<ConsultarGradoResult> ConsultarGrado()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarGradoResult> datos = db.ConsultarGrado().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaGradoResult ConsultaGrado(int IdGrado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaGrado(IdGrado).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminarGrado(int IdGrado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaGrado(IdGrado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarGrado(int IdGrado, string Descripcion, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarGrado(IdGrado, Descripcion, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarGrado(string Descripcion, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarGrado(Descripcion, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

	}
}
