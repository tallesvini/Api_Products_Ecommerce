using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using ProductsAPI.Models;
using ProductsAPI.Pagination;
using ProductsAPI.Repository.Interfaces;

namespace ProductsAPI.Repository
{
    public class CategoryRepository : AbstractRepository<CategoryModel>, ICategoryRepository
    {
        public CategoryRepository(ProductDBContext context) : base(context) { }

        public async Task<PagedList<CategoryModel>> GetCategory(Parameters parameters)
        {
            return await PagedList<CategoryModel>.ToPagedList(Get().OrderBy(on => on.Id), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<CategoryModel>> GetCategoryProducts(Parameters parameters)
        {
            return await PagedList<CategoryModel>.ToPagedList(Get().Include(on => on.Products).OrderBy(on => on.Id), parameters.PageNumber, parameters.PageSize);
        }
    }
}
