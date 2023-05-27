using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;
using MinhaApi.Repository.Interfaces;

namespace MinhaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IAboutProductRepository _aboutProductRepository;
        public ProductController(IProductRepository productRepository, IAboutProductRepository aboutProductRepository) 
        {
            _productRepository = productRepository;
            _aboutProductRepository = aboutProductRepository;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<List<ProductModel>>> GetAllProducts()
        {
            List<ProductModel> products = await _productRepository.GetAllProducts();
            return Ok(products);
        }

        //GetProductById/{id} 
        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<ProductModel>> GetProductById(int id)
        {
            ProductModel products = await _productRepository.GetProductById(id);
            return Ok(products);
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult<ProductModel>> AddProduct([FromBody] ProductModel product)
        {     
            try
            {
                ProductModel products = await _productRepository.AddProduct(product);

                AboutProductModel aboutProductModel = new AboutProductModel();
                aboutProductModel.ProductId = products.Id;
                aboutProductModel.AvailableOnFactory = true;
                AboutProductModel aboutProduct = await _aboutProductRepository.AddAboutProduct(aboutProductModel);

                return Ok(products);
            }
            catch
            {
                throw new Exception("Couldn't add the new product..."); 
            }

        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<ActionResult<ProductModel>> UpdateProduct([FromBody] ProductModel product, int id)
        {
            product.Id = id;
            ProductModel products = await _productRepository.UpdateProduct(product, id);

            return Ok(products);
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult<ProductModel>> DeleteProduct(int id)
        {
            bool products = await _productRepository.DeleteProduct(id);

            return Ok(products);
        }
    }
}
