using MinhaApi.Models;
using ProductsAPI.Pagination;
using ProductsAPI.Repository.Interfaces;

namespace MinhaApi.Repository.Interfaces
{
    public interface IProductRepository : IAbstractRepository<ProductModel>
    {
        Task<PagedList<ProductModel>> GetProducts(Parameters parameters);   
    }
}
