using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductsAPI.DTOs;
using ProductsAPI.Models;
using ProductsAPI.Pagination;
using ProductsAPI.Repository.Interfaces;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #region Pagination --

        private void AddPaginationHeader(PagedList<CategoryModel> category)
        {
            var metadata = new
            {
                category.TotalCount,
                category.PageSize,
                category.CurrentPage,
                category.TotalPages,
                category.HasNext,
                category.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        }

        #endregion

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategoryAsync([FromQuery] Parameters parameters)
        {
            var category = await _unitOfWork.CategoryRepository.GetCategory(parameters);

            if (!category.Any()) return NotFound();

            AddPaginationHeader(category);

            var categoryDto = _mapper.Map<List<CategoryDTO>>(category);

            return Ok(categoryDto);
        }

        [Authorize(Roles = "User")]
        [HttpGet("{id:int:min(1)}", Name = "GetById")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryAsync(int id)
        {
            CategoryModel category = await _unitOfWork.CategoryRepository.GetById(x => x.Id == id);

            if (category == null) return NotFound();

            var categoryDto = _mapper.Map<CategoryDTO>(category);

            return Ok(categoryDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> PostCategoryAsync(CategoryDTO? categoryDto)
        {
            try
            {
                if (categoryDto == null) return BadRequest();

                var category = _mapper.Map<CategoryModel>(categoryDto);

                _unitOfWork.CategoryRepository.Add(category);
                await _unitOfWork.Commit();

                return new CreatedAtRouteResult("GetById", new { id = category.Id }, categoryDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There was an error processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<CategoryDTO>> PutCategoryAsync(int id, CategoryDTO? categoryDto)
        {
            try
            {
                if(id != categoryDto.Id) return BadRequest();

                var category = _mapper.Map<CategoryModel>(categoryDto);

                _unitOfWork.CategoryRepository.Update(category);
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
        public async Task<ActionResult<CategoryDTO>> DeleteCategoryAsync(int id)
        {
            try
            {
                CategoryModel getCategory = await _unitOfWork.CategoryRepository.GetById(x => x.Id == id);

                if(getCategory == null) return NotFound(); 

                _unitOfWork.CategoryRepository.Delete(getCategory);
                await _unitOfWork.Commit();

                var categoryDto = _mapper.Map<CategoryDTO>(getCategory);

                return Ok(categoryDto);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "There was an error processing your request.");
            }
        }
    }
}
