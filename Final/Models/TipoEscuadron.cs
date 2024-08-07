using System.ComponentModel.DataAnnotations.Schema;

namespace Practica_Final.Models
{
    [Table("Tipo_Escuadrones")]
    public class TipoEscuadron
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
    }
}
