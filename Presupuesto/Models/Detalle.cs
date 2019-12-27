using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Presupuesto.Models
{
    public class Detalle
    {
        public int Id { get; set; }                
        public int? AnalisisUnitarioId { get; set; }
        [ForeignKey("AnalisisUnitarioId")]
        public virtual AnalisisUnitario? AnalisisUnitario { get; set; }                        
        public int? ItemId { get; set; }
        [ForeignKey("ItemId")]
        public virtual Item? Item { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public int Precio { get; set; }
        public float Rendimiento { get; set; }
        public float Desperdicio { get; set; }
        public string DetalleDe { get; set; }

        
    }
}
