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

	}
}
