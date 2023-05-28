using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Repository.Interfaces;

namespace MinhaApi.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext _dbContext;
        public ProductRepository(ProductDBContext productDBContext) 
        { 
            _dbContext = productDBContext;
        }
        public async Task<ProductModel> GetProductById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<ProductModel> AddProduct(ProductModel product)
        {
            await _dbContext.Products.AddAsync(product);
            _dbContext.SaveChanges();

            return product;
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product, int id)
        {
            ProductModel productById = await GetProductById(id);

            if(productById == null)
            {
                throw new ArgumentException($"Produto para o Id: {id} não foi encontrado...");
            }

            productById.Name = product.Name;
            productById.Description = product.Description; 
            productById.Price = product.Price;
            productById.Category = product.Category;
            productById.Status = product.Status;

            _dbContext.Products.Update(productById);
            await _dbContext.SaveChangesAsync();

            return productById;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            ProductModel productById = await GetProductById(id);

            if (productById == null)
            {
                throw new ArgumentException($"Produto para o Id: {id} não foi encontrado...");
            }

            _dbContext.Products.Remove(productById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
