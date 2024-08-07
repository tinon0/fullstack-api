using System.ComponentModel.DataAnnotations.Schema;

namespace Practica_Final.Models
{
    [Table("SoladosXEscuadrones")]
    public class SoldadoXEscuadron
    {
        public Guid Id { get; set; }
        public Guid IdEscuadron { get; set; }
        public Guid IdSoldado { get; set; }
        public string Actividad { get; set; }
        public DateTime FechaCreacion { get; set; }
        [ForeignKey("IdSoldado")] public Soldado Soldado { get; set; }
        [ForeignKey("IdEscuadron")] public Escuadron Escuadron { get; set; }
    }
}
