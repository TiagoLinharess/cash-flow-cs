using CashFlow.Application.UseCases.Expenses.Create;
using CashFlow.Application.UseCases.Expenses.Read;
using CashFlow.Application.UseCases.Expenses.ReadAt;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredExpenseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(
            [FromServices] ICreateExpenseUseCase createExpenseUseCase,
            [FromBody] RequestRegisterExpenseJson request)
        {
            var response = await createExpenseUseCase.Execute(request);
            return Created(string.Empty, response);
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ResponseExpensesJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Read([FromServices] IReadExpensesUseCase readExpensesUseCase)
        {
            var response = await readExpensesUseCase.Execute();

            if (response.Expenses.Count == 0) return NoContent();
            
            return Ok(response);
        }
        
        [HttpGet]
        [Route("{id:long}")]
        [ProducesResponseType(typeof(ResponseExpenseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ReadAt(
            [FromServices] IReadAtExpenseUseCase readAtExpenseUseCase,
            [FromRoute] long id)
        {
            var response = await readAtExpenseUseCase.Execute(id);
            return Ok(response);
        }
    }
}
