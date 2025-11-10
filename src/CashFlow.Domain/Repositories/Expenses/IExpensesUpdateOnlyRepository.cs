using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesUpdateOnlyRepository
{
    Task<Expense?> ReadAt(long id);
    void Update(Expense expense);
}