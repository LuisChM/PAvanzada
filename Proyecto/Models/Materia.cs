using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Materia
    {
        public int IdMateria { get; set; }
        public string DescripcionMateria { get; set; }
        public int? IdInstitucion { get; set; }
        public bool Estado { get; set; }
    }
}