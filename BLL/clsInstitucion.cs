using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsInstitucion
	{
		public List<ConsultarInstitucionResult> ConsultarInstitucion()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarInstitucionResult> datos = db.ConsultarInstitucion().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public ConsultaInstitucionResult ConsultaInstitucion(int IdInstitucion)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ConsultaInstitucion(IdInstitucion).FirstOrDefault();
				return dato;
			}
			catch (Exception ex)
			{

				throw;
			}
		}
		public bool EliminaInstitucion(int IdInstitucion)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.EliminaInstitucion(IdInstitucion);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool ActualizarInstitucion(int IdInstitucion, string Descripcion, string Telefono, string Encargado, string Direccion, char Provincia, string Canton, string Distrito, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.ActualizarInstitucion(IdInstitucion, Descripcion, Telefono, Encargado, Direccion, Provincia, Canton, Distrito, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
		public bool AgregarInstitucion(string Descripcion, string Telefono, string Encargado, string Direccion, char Provincia, string Canton, string Distrito, bool Estado)
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				var dato = db.AgregarInstitucion(Descripcion, Telefono, Encargado, Direccion, Provincia, Canton, Distrito, Estado);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

    }
}
