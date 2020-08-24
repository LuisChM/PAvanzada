using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class DocenteGrado
    { 
        public int IdDocenteGrado { get; set; }
        public int IdDocente { get; set; }
        public int IdGrado { get; set; }
    }
}