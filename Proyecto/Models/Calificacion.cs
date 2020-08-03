using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Calificacion
    {
        public int IdCalificacion { get; set; }
        public int IdTipoOperacion { get; set; }
        public int IdEstudiante { get; set; }
        public int IdDocente { get; set; }
        public int IdMateria { get; set; }
        public decimal Nota { get; set; }
        public DateTime Fecha { get; set; }

    }
}