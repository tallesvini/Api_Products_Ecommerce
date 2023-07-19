using MinhaApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProductsAPI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        [MaxLength(128)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        [MaxLength (256)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The field is mandatory.")]
        [Url(ErrorMessage = "Incorrect format.")]
        public string? ImageUrl { get; set; }

        [JsonIgnore]
        public ICollection<ProductModel>? Products { get; set; }
    }
}
