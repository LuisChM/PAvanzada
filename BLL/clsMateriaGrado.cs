using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsMateriaGrado
	{
		public List<ConsultarMateriaGradoResult> ConsultarMateriaGrado()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarMateriaGradoResult> datos = db.ConsultarMateriaGrado().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaMateriaGradoResult ConsultaMateriaGrado(int IdMateriaGrado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaMateriaGrado(IdMateriaGrado).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminarMateriaGrado(int IdMateriaGrado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaMateriaGrado(IdMateriaGrado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarMateriaGrado(int IdMateriaGrado, int IdMateria, int IdGrado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarMateriaGrado(IdMateriaGrado, IdMateria, IdGrado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarMateriaGrado(int IdMateria, int IdGrado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarMateriaGrado(IdMateria, IdGrado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

	}
}
