using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Presupuesto.Models
{
    public class AnalisisUnitario
    {
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        [ForeignKey("ProyectoId")]
        public virtual Proyecto Proyecto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }     
        
        public string Grupo { get; set; }
        public string Clasificacion { get; set; }
        public long ValorUnitario { get; set; }
        public List<Detalle> Detalles { get; set; }

        public int CostoMateriales { get; set; }
        public int CostoEquipo { get; set; }
        public int CostoManoObra { get; set; }
    }
}
