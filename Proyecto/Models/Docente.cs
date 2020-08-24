using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Docente
    {
        public int IdDocente { get; set; }
        public int IdInstitucion { get; set; }
        public int IdUsuario { get; set; }
        public int IdMateria { get; set; }

        public bool Estado { get; set; }
    }
}