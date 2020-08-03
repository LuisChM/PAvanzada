using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
	public class clsRol
	{
		public List<ConsultarRolResult> ConsultarRol()
		{
			try
			{
				DatosDataContext db = new DatosDataContext();
				List<ConsultarRolResult> datos = db.ConsultarRol().ToList();
				return datos;
			}
			catch (Exception ex)
			{

				throw;
			}

		}
	}
}

