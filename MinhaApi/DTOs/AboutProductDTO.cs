using MinhaApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductsAPI.DTOs
{
    public class AboutProductDTO
    {
        public int Id { get; set; }

        public bool IsAvailableOnFactory { get; set; }

        public int? ProductId { get; set; }

        [JsonIgnore]
        public virtual ProductDTO? Product { get; set; }
    }
}
