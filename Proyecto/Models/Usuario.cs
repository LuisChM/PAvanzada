using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Usuario
    {
		public int IdUsuario { get; set; }

		public int IdInstitucion { get; set; }

		public int IdTipoIdentificacion { get; set; }

		public string Identificacion { get; set; }

		public string Nombre { get; set; }

		public string Apellido1 { get; set; }

		public string Apellido2 { get; set; }

		public string Clave { get; set; }

		public string? Telefono { get; set; }

		public string? Direccion { get; set; }

		public string? Correo { get; set; }

		public DateTime FechaNacimiento { get; set; }

		public bool Estado { get; set; }
	}
}