namespace MinhaApi.Models
{
    public class AboutProductModel
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public DateTime? AddProduct { get; set; } = DateTime.Now;
        public bool AvailableOnFactory { get; set; }

        public virtual ProductModel? Product { get; set; }
    }
}
