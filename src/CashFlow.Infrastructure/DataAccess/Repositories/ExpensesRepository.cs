using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesWriteOnlyRepository, IExpensesReadOnlyRepository
    {
        private readonly CashFlowDbContext _dbContext;
        public ExpensesRepository(CashFlowDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Expense expense) => await _dbContext.Expenses
            .AddAsync(expense);
        
        public async Task<List<Expense>> Read() => await _dbContext.Expenses
            .AsNoTracking()
            .ToListAsync();
        
        public async Task<Expense?> ReadAt(long id) => await _dbContext.Expenses
            .AsNoTracking()
            .FirstOrDefaultAsync(expense => expense.Id == id);

        public async Task<bool> Delete(long id)
        {
            var result = await _dbContext.Expenses.FirstOrDefaultAsync(expense => expense.Id == id);

            if (result is null) return false;

            _dbContext.Expenses.Remove(result);
            
            return true;
        }
    }
}
