using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Repository.Interfaces;

namespace MinhaApi.Repository
{
    public class AboutProductRepository : IAboutProductRepository
    {
        private readonly ProductDBContext _dbContext;
        public AboutProductRepository(ProductDBContext productDBContext) 
        { 
            _dbContext = productDBContext;
        }

        public async Task<List<AboutProductModel>> GetAllAboutProducts()
        {
            return await _dbContext.AboutProducts.ToListAsync();
        }

        public async Task<AboutProductModel> GetAboutProductById(int id)
        {
            return await _dbContext.AboutProducts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<AboutProductModel> AddAboutProduct(AboutProductModel aboutProduct)
        {
            await _dbContext.AboutProducts.AddAsync(aboutProduct);
            _dbContext.SaveChanges();

            return aboutProduct;
        }
    }
}
