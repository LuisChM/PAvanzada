using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Institucion
    {
		public int IdInstitucion { get; set; }

		public string Descripcion { get; set; }

		public string Telefono { get; set; }

		public string Encargado { get; set; }

		public string? Direccion { get; set; }

		public char Provincia { get; set; }

		public string Canton { get; set; }

		public string Distrito { get; set; }

		public bool Estado { get; set; }
	}
}