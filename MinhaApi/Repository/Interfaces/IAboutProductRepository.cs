using MinhaApi.Models;
using ProductsAPI.Pagination;
using ProductsAPI.Repository.Interfaces;

namespace MinhaApi.Repository.Interfaces
{
    public interface IAboutProductRepository : IAbstractRepository<AboutProductModel>
    {
        Task<PagedList<AboutProductModel>> GetAboutProduct(Parameters parameters);
        Task<PagedList<AboutProductModel>> GetAllAboutProducts(Parameters parameters);
    }
}
