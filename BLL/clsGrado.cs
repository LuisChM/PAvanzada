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

	}
}
