using MinhaApi.Enums;

namespace ProductsAPI.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Sku { get; set; }

        public string? Description { get; set; }

        public string? Size { get; set; }

        public string? Color { get; set; }

        public GenderProduct Gender { get; set; }

        public decimal? Price { get; set; }


        public int CategoryId { get; set; }
    }
}
