using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;
using Newtonsoft.Json;
using ProductsAPI.DTOs;
using ProductsAPI.Pagination;
using ProductsAPI.Repository.Interfaces;

namespace MinhaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Pagination --
        private void AddPaginationHeader(PagedList<ProductModel> products)
        {
            var metadata = new
            {
                products.TotalCount,
                products.PageSize,
                products.CurrentPage,
                products.TotalPages,
                products.HasNext,
                products.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        }
        #endregion

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProductAsync([FromQuery] Parameters parameters)
        {
             var products = await _unitOfWork.ProductRepository.GetProducts(parameters);

             if (!products.Any()) return NotFound();

             AddPaginationHeader(products);

             var productDto = _mapper.Map<List<ProductDTO>>(products);

             return Ok(productDto);
        }

        [Authorize(Roles = "User")]
        [HttpGet("{id:int:min(1)}", Name = "GetProduct")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
             ProductModel product = await _unitOfWork.ProductRepository.GetById(x => x.Id == id);

             if(product == null) return NotFound();

            var productDto = _mapper.Map<ProductDTO>(product);

            return Ok(productDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProductAsync(ProductDTO productDto)
        {     
            try
            {
                if(productDto == null) return BadRequest();

                var product = _mapper.Map<ProductModel>(productDto);

                _unitOfWork.ProductRepository.Add(product);
                await _unitOfWork.Commit();

                _unitOfWork.AboutProductRepository.Add(new AboutProductModel { ProductId = productDto.Id });
                await _unitOfWork.Commit();

                return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, productDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There was an error processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<ProductDTO>> UpdateProductAsync(int id, ProductDTO productDto)
        {
            try
            {
                if(id != productDto.Id) return BadRequest();

                var product = _mapper.Map<ProductModel>(productDto);

                _unitOfWork.ProductRepository.Update(product);
                await _unitOfWork.Commit();

                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There was an error processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int:min(1)}")]
        public async Task<ActionResult<ProductDTO>> DeleteProductAsync(int id)
        {
            try
            {
                var product = await _unitOfWork.ProductRepository.GetById(x => x.Id == id);

                if(product == null) return BadRequest();

                _unitOfWork.ProductRepository.Delete(product);
                await _unitOfWork.Commit();

                var productDto = _mapper.Map<ProductModel>(product);

                return Ok(productDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There was an error processing your request.");
            }
        }
    }
}
