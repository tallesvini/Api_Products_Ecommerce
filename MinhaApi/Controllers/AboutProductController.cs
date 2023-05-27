using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;
using MinhaApi.Repository;
using MinhaApi.Repository.Interfaces;

namespace MinhaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutProductController : ControllerBase
    {
        private readonly IAboutProductRepository _iaboutProductRepository;
        public AboutProductController(IAboutProductRepository iaboutProductRepository)
        {
            _iaboutProductRepository = iaboutProductRepository;
        }

        [HttpGet("GetAllAboutProducts")]
        public async Task<ActionResult<List<AboutProductModel>>> GetAllAboutProducts()
        {
            List<AboutProductModel> aboutProducts = await _iaboutProductRepository.GetAllAboutProducts();
            return Ok(aboutProducts);
        }

        [HttpGet("GetAboutProductById/{id}")]
        public async Task<ActionResult<AboutProductModel>> GetAboutProductById(int id)
        {
            AboutProductModel aboutProducts = await _iaboutProductRepository.GetAboutProductById(id);
            return Ok(aboutProducts);
        }
    }
}
