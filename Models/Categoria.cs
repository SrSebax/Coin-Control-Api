using System.ComponentModel.DataAnnotations;

namespace CoinControl.Api.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Tipo { get; set; }

        public string? Icono { get; set; }

        public string? Color { get; set; }
    }
}
