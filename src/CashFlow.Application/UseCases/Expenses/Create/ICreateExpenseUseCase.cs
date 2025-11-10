using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Create
{
    public interface ICreateExpenseUseCase
    {
        public Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request);
    }
}
