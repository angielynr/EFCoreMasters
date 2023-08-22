using ExpenseTracker.API.DTOs;
using ExpenseTracker.API.Extensions;
using ExpenseTracker.Application.Interface;
using ExpenseTracker.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _service;

        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var expenses = _service.GetAll();

            if(expenses == null) { 
                return NoContent();
            }

            return Ok(expenses);
        }

        [HttpGet]
        public IActionResult GetAllOrderedByAmount() 
        {
            var expenses = _service.GetAllOrderedByAmount();

            if(expenses == null)
            {
                return NoContent();
            }

            return Ok(expenses);
        }

        [HttpPost]
        public IActionResult Add(ExpenseDTO expense)
        {
            var expenseAdded = _service.Add(expense.DTOToExpense());

            return Created("api/Expense/Add", expenseAdded);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var expenseToDelete = _service.GetSingle(id);

            if (expenseToDelete == null)
            {
                return NotFound();
            }

            _service.Delete(expenseToDelete);

            return Ok();
        }
    }
}
