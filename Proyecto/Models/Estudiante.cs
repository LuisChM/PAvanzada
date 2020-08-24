using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }
        public int IdInstitucion { get; set; }
        public int IdUsuario { get; set; }
        public int IdGrado { get; set; }
        public bool Estado { get; set; }


    }
}