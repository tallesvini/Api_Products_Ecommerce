using MinhaApi.Models;

namespace MinhaApi.Repository.Interfaces
{
    public interface IAboutProductRepository
    {
        Task<List<AboutProductModel>> GetAllAboutProducts();
        Task<AboutProductModel> GetAboutProductById(int id);
        Task<AboutProductModel> AddAboutProduct(AboutProductModel aboutProduct);
    }
}
