using System.Text.Json.Serialization;

namespace ProductsAPI.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [JsonIgnore]
        public ICollection<ProductDTO>? Products { get; set; }
    }
}
