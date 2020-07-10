using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
	public class TipoOperacion
	{
		public int IdTipoOperacion { get; set; }

		public string Descripcion { get; set; }

		public bool Estado { get; set; }
	}
}