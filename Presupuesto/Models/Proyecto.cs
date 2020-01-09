using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Presupuesto.Models
{
    public class Proyecto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre_Obra { get; set; }
        [Required]
        public string Contratante { get; set; }
        [Required]
        public string Proponente { get; set; }
        [Required]
        public string Fecha_Presentacion { get; set; }
        [Required]
        public string Fecha_Modificacion { get; set; }
        [Required]
        public string Comentarios { get; set; }
    }
}
