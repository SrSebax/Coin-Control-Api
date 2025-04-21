using System.ComponentModel.DataAnnotations;

namespace CoinControl.Api.Models
{
    public class User
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? Uid { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
    }
}
