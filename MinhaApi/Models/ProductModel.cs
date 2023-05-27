using MinhaApi.Enums;

namespace MinhaApi.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public GenderProduct Gender { get; set; }
        public decimal? Price { get; set; }
        public CategoryProduct Category { get; set;}
        public StatusProduct Status { get; set;}
        public int Amount { get; set; }     
    }   
}
