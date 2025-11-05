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
        public IActionResult Create([FromBody] RequestRegisterExpenseJson request)
        {
            var useCase = new CreateExpenseUseCase();
            var response = useCase.Execute(request);
            return Created(string.Empty, response);
        }
    }
}
