using System.ComponentModel.DataAnnotations.Schema;

namespace Practica_Final.Models
{
    [Table("Escuadrones")]
    public class Escuadron
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Info { get; set; }
        public Guid IdTipo { get; set; }
        [ForeignKey("IdTipo")] public TipoEscuadron TipoEscuadron { get; set; }
    }
}
