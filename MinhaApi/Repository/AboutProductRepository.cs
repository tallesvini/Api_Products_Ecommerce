using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Repository.Interfaces;
using ProductsAPI.Pagination;
using ProductsAPI.Repository;

namespace MinhaApi.Repository
{
    public class AboutProductRepository : AbstractRepository<AboutProductModel>, IAboutProductRepository
    {
        public AboutProductRepository(ProductDBContext context) : base(context) { }

        public async Task<PagedList<AboutProductModel>> GetAboutProduct(Parameters parameters)
        {
            return await PagedList<AboutProductModel>.ToPagedList(Get().OrderBy(on => on.Id), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<AboutProductModel>> GetAllAboutProducts(Parameters parameters)
        {
            return await PagedList<AboutProductModel>.ToPagedList(Get().Include(x => x.Product), parameters.PageNumber, parameters.PageSize);
        }
    }
}
