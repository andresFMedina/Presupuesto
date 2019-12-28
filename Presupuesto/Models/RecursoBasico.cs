using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presupuesto.Models
{
    public class RecursoBasico
    {
        public int Id { get; set; }        
        [Required]
        public string Codigo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public string Grupo { get; set; }
        public string Clasificacion { get; set; }
        public long Precio { get; set; }
        public string Fecha { get; set; }
    }
}
