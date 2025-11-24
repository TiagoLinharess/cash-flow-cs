using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;

internal class ExpensesRepository : IExpensesWriteOnlyRepository, IExpensesReadOnlyRepository, IExpensesUpdateOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpensesRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Expense expense)
    {
        await _dbContext.Expenses.AddAsync(expense);
    }

    public async Task<List<Expense>> Read(User user)
    {
        return await _dbContext
            .Expenses
            .AsNoTracking()
            .Where(expense => expense.UserId == user.Id)
            .ToListAsync();
    }

    async Task<Expense?> IExpensesReadOnlyRepository.ReadAt(User user, long id)
    {
        return await _dbContext
            .Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(expense => expense.Id == id && user.Id == expense.UserId);
    }

    async Task<Expense?> IExpensesUpdateOnlyRepository.ReadAt(User user, long id)
    {
        return await _dbContext
            .Expenses
            .FirstOrDefaultAsync(expense => expense.Id == id && user.Id == expense.UserId);
    }

    public async Task<List<Expense>> FilterByMonth(User user, DateOnly date)
    {
        var startDate = new DateTime(year: date.Year, month: date.Month, day: 1).Date;
        var endDate = new DateTime(
            year: date.Year,
            month: date.Month,
            day: DateTime.DaysInMonth(year: date.Year, month: date.Month),
            hour: 23,
            minute: 59,
            second: 59);

        return await _dbContext
            .Expenses
            .AsNoTracking()
            .Where(expense => expense.UserId == user.Id && expense.Date >= startDate && expense.Date <= endDate)
            .OrderBy(expense => expense.Date)
            .ThenBy(expense => expense.Title)
            .ToListAsync();
    }

    public void Update(Expense expense)
    {
        _dbContext.Expenses.Update(expense);
    }

    public async Task Delete(long id)
    {
        var result = await _dbContext.Expenses.FirstAsync(expense => expense.Id == id);
        _dbContext.Expenses.Remove(result);
    }
}
