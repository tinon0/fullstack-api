using System.ComponentModel.DataAnnotations.Schema;

namespace Practica_Final.Models
{
    [Table("Soldados")]
    public class Soldado
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public DateTime InicioActividades { get; set; }
        public string Localidad { get; set; }
    }
}
