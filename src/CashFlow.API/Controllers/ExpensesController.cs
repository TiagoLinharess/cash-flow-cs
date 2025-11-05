using CashFlow.Application.UseCases.Expenses.Create;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;
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
            try
            {
                var useCase = new CreateExpenseUseCase();
                var response = useCase.Execute(request);
                return Created(string.Empty, response);
            }
            catch (ErrorOnValidationException ex)
            {
                var errorResponse = new ResponseErrorJson(ex.Errors);
                return BadRequest(errorResponse);
            }
            catch
            {
                var errorResponse = new ResponseErrorJson("unkown error.");
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
