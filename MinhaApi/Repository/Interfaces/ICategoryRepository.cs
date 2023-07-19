using ProductsAPI.Models;
using ProductsAPI.Pagination;

namespace ProductsAPI.Repository.Interfaces
{
    public interface ICategoryRepository : IAbstractRepository<CategoryModel>
    {
        Task<PagedList<CategoryModel>> GetCategory(Parameters parameters);
        Task<PagedList<CategoryModel>> GetCategoryProducts(Parameters parameters);
    }
}
