using EFCoreAssignment.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _service.GetProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _service.GetProduct(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductApiModel vm)
        {
            var result = await _service.CreateProduct(new CreateProductDto(vm.Name, vm.ShopId));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductApiModel vm)
        {
            await _service.UpdateProduct(new UpdateProductDto(vm.Id, vm.Name, vm.ShopId));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _service.DeleteProduct(id);
            return Ok();
        }
    }

    public record CreateProductApiModel(string Name, int ShopId);
    public record UpdateProductApiModel(int Id, string Name, int ShopId);
}
