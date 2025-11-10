using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.ReadAt;

public interface IReadAtExpenseUseCase
{
    Task<ResponseExpenseJson> Execute(long id);
}