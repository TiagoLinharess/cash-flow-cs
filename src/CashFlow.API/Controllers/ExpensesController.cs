using CashFlow.Application.UseCases.Expenses.Create;
using CashFlow.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(
            [FromServices] ICreateExpenseUseCase createExpenseUseCase,
            [FromBody] RequestRegisterExpenseJson request)
        {
            var response = createExpenseUseCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
