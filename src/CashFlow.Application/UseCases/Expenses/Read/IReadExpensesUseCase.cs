using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Read;

public interface IReadExpensesUseCase
{
    public Task<ResponseExpensesJson> Execute();
}