using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Models
{
    public class MateriaGrado
    {
        public int IdMateriaGrado { get; set; }
        public int IdMateria { get; set; }
        public int IdGrado { get; set; }
        public string DescripcionMateria { get; set; }
        public string Descripcion { get; set; }
    }
}