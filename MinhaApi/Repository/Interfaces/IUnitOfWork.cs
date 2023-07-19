using MinhaApi.Repository.Interfaces;

namespace ProductsAPI.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IAboutProductRepository AboutProductRepository { get; }

        Task Commit();
    }
}
