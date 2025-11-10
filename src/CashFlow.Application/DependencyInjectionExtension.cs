using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Expenses.Create;
using CashFlow.Application.UseCases.Expenses.Delete;
using CashFlow.Application.UseCases.Expenses.Read;
using CashFlow.Application.UseCases.Expenses.ReadAt;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        { 
            AddAutoMapper(services); 
            AddUseCases(services);
        }
        
        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(cfg => cfg.AddProfile<ExpenseMapping>());
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<ICreateExpenseUseCase, CreateExpenseUseCase>();
            services.AddScoped<IReadExpensesUseCase, ReadExpensesUseCase>();
            services.AddScoped<IReadAtExpenseUseCase, ReadAtExpenseUseCase>();
            services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
        }
    }
}
