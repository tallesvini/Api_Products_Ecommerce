using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Repository.Interfaces;
using ProductsAPI.Pagination;
using ProductsAPI.Repository;

namespace MinhaApi.Repository
{
    public class ProductRepository : AbstractRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(ProductDBContext context) : base(context) { }

        public async Task<PagedList<ProductModel>> GetProducts(Parameters parameters)
        {
            return await PagedList<ProductModel>.ToPagedList(Get().OrderBy(on => on.Id), parameters.PageNumber, parameters.PageSize);
        }

    }
}
