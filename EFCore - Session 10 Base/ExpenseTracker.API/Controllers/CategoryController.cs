using ExpenseTracker.API.DTOs;
using ExpenseTracker.API.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Application;
using ExpenseTracker.Application.Interface;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _service.GetAll();

            if (categories == null)
            {
                return NoContent();
            }

            return Ok(categories);
        }

        [HttpPost]
        public IActionResult Add(CategoryDTO category) {

            var addedCategory = _service.Add(category.DTOToCategory());

            return Created("api/Category/Add", addedCategory);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var categoryToDelete = _service.GetSingle(id);

            if(categoryToDelete == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
