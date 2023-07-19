using MinhaApi.Data;
using MinhaApi.Repository;
using MinhaApi.Repository.Interfaces;
using ProductsAPI.Repository.Interfaces;

namespace ProductsAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private ProductRepository _productRepo;
        private CategoryRepository _categoryRepo;
        private AboutProductRepository _aboutProductRepo;
        public ProductDBContext _context;

        public UnitOfWork(ProductDBContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepo = _productRepo ?? new ProductRepository(_context);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepo = _categoryRepo ?? new CategoryRepository(_context);
            }
        }

        public IAboutProductRepository AboutProductRepository
        {
            get
            {
                return _aboutProductRepo = _aboutProductRepo ?? new AboutProductRepository(_context);
            }
        }

        public async Task Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
