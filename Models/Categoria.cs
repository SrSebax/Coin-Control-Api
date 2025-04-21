using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinControl.Api.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        public string Uid { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public string GastoProgramado { get; set; }

        public string Icono { get; set; }

        public string Color { get; set; }

        public string Frecuencia { get; set; }

        [ForeignKey("Uid")]
        public User User { get; set; }
    }
}
