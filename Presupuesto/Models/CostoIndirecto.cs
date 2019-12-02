using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Presupuesto.Models
{
    public class CostoIndirecto
    {
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public float Porcentaje { get; set; }        
        public int? ProyectoId { get; set; }
        [ForeignKey("ProyectoId")]
        public virtual Proyecto Proyecto { get; set; }
    }
}
