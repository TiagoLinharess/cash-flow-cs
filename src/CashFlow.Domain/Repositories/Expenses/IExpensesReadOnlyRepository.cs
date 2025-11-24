using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesReadOnlyRepository
{
    Task<List<Expense>> Read(User user);
    Task<Expense?> ReadAt(User user, long id);
    Task<List<Expense>> FilterByMonth(User user, DateOnly date);
}