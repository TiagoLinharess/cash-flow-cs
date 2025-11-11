using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesReadOnlyRepository
{
    Task<List<Expense>> Read();
    Task<Expense?> ReadAt(long id);
    Task<List<Expense>> FilterByMonth(DateOnly date);
}