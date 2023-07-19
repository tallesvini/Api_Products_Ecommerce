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
    public class AboutProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AboutProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Pagination --
        private void AddPaginationHeaders(PagedList<AboutProductModel> aboutProduct)
        {
            var metadata = new
            {
                aboutProduct.TotalCount,
                aboutProduct.PageSize,
                aboutProduct.CurrentPage,
                aboutProduct.TotalPages,
                aboutProduct.HasNext,
                aboutProduct.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        }
        #endregion

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List<AboutProductDTO>>> GetAboutProducts([FromQuery] Parameters parameters)
        {
            var aboutProducts = await _unitOfWork.AboutProductRepository.GetAboutProduct(parameters);

            if (!aboutProducts.Any()) return NotFound();

            AddPaginationHeaders(aboutProducts);

            var aboutProductDto = _mapper.Map<List<AboutProductDTO>>(aboutProducts);

            return Ok(aboutProductDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<AboutProductDTO>> GetAboutProducts(int id)
        {
            var aboutProducts = await _unitOfWork.AboutProductRepository.GetById(x => x.Id == id);

            if (aboutProducts == null) return NotFound();

            var aboutProductDto = _mapper.Map<AboutProductDTO>(aboutProducts);

            return Ok(aboutProductDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("product/{id:int:min(1)}")] 
        public async Task<ActionResult<List<AboutProductDTO>>> GetProductById(int id)
        {
            var aboutProducts = await _unitOfWork.AboutProductRepository.GetById(on => on.ProductId == id);

            if (aboutProducts == null) return NotFound();

            var aboutProductDto = _mapper.Map<AboutProductDTO>(aboutProducts);

            return Ok(aboutProductDto);
        }
    }
}
