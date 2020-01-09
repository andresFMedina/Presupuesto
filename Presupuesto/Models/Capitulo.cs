using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Presupuesto.Models
{

    public class Capitulo
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Descripcion { get; set; }
        public int ProyectoId { get; set; }
        [ForeignKey("ProyectoId")]
        public virtual Proyecto Proyecto { get; set; }
        public int Subtotal { get; set; }
        public int CostoMateriales { get; set; }
        public int CostoEquipo { get; set; }
        public int CostoManoObra { get; set; }

    }
}
