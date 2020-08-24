using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class clsDocente
    {
		public List<ConsultarDocenteResult> ConsultarDocente()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarDocenteResult> datos = db.ConsultarDocente().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaDocenteResult ConsultaDocente(int IdDocente)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaDocente(IdDocente).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminarDocente(int IdDocente)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaDocente(IdDocente);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarDocente(int IdDocente, int IdInstitucion, int IdUsuario, int IdMateria, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarDocente(IdDocente, IdInstitucion, IdUsuario, IdMateria, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarDocente(int IdInstitucion, int IdUsuario, int IdMateria, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarDocente(IdInstitucion, IdUsuario, IdMateria, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
