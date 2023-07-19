using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MinhaApi.Models
{
    public class AboutProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        public DateTime? DateAddProduct { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "The field is mandatory.")]
        [MaxLength(1)]
        public bool IsAvailableOnFactory { get; set; } = true;

        [Required(ErrorMessage = "The field is mandatory.")]
        [MaxLength(128)]
        public string? WhoAdded { get; set; } = "API";

        public int? ProductId { get; set; }

        [JsonIgnore]
        public virtual ProductModel? Product { get; set; }
    }
}
