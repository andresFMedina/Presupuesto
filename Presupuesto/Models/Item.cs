using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Presupuesto.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int ProyectoId { get; set; }
        [ForeignKey("ProyectoId")]
        public virtual Proyecto Proyecto { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public float Cantidad { get; set; }
        // Temporal mientras se define si es un Objeto//
        public int Frente { get; set; }
        ///////////////////////////////////////////////
        ///// Temporal mientras se define si es un Objeto//
        public int Actividad{ get; set; }
        ///////////////////////////////////////////////
        public int Aporte { get; set; }
        public virtual List<Detalle> Detalles { get; set; }
        public int ValorUnitario { get; set; }
        public int? NumeroCapitulo { get; set; }
        public int? CapituloId { get; set; }
        [ForeignKey("CapituloId")]
        public virtual Capitulo capitulo { get; set; }
        public int CostoMateriales { get; set; }
        public int CostoEquipo { get; set; }
        public int CostoManoObra { get; set; }
    }
}
