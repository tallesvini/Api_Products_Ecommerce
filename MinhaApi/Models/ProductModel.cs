using MinhaApi.Enums;
using ProductsAPI.Models;
using ProductsAPI.Validations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MinhaApi.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        [MaxLength(128)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        [SkuValidation]
        public string? Sku { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        [MaxLength(256)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        [MaxLength(16)]
        public string? Size { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        public string? Color { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        public GenderProduct Gender { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        public StatusProduct Status { get; set;}

        [Required(ErrorMessage = "The field is mandatory.")]
        public int Amount { get; set; }    


        public int CategoryId { get; set; }

        [JsonIgnore]
        public CategoryModel? Category { get; set; }

        [JsonIgnore]
        public ICollection<AboutProductModel>? AboutProduct { get; set; }
    }   
}
