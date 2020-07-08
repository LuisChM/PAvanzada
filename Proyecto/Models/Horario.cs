using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public int IdGrado { get; set; }
        public string Materia { get; set; }
        public string Descripcion { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string ColorFondo { get; set; }
        public bool DiaCompleto { get; set; }
    }
}