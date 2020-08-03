using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsTipoOperacion
	{
		public List<ConsultarTipoOperacionResult> ConsultarTipoOperacion()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarTipoOperacionResult> datos = db.ConsultarTipoOperacion().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

	}
}
