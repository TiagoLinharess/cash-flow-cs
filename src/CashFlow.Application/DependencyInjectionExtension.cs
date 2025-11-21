using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Expenses.Create;
using CashFlow.Application.UseCases.Expenses.Delete;
using CashFlow.Application.UseCases.Expenses.Read;
using CashFlow.Application.UseCases.Expenses.ReadAt;
using CashFlow.Application.UseCases.Expenses.Update;
using CashFlow.Application.UseCases.Reports.Excel;
using CashFlow.Application.UseCases.Reports.Pdf;
using CashFlow.Application.UseCases.Users.Login;
using CashFlow.Application.UseCases.Users.Register;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application;

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
        services.AddAutoMapper(cfg => cfg.AddProfile<UserMapping>());
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateExpenseUseCase, CreateExpenseUseCase>();
        services.AddScoped<IReadExpensesUseCase, ReadExpensesUseCase>();
        services.AddScoped<IReadAtExpenseUseCase, ReadAtExpenseUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
        services.AddScoped<IGenerateExpensesReportExcelUseCase, GenerateExpensesReportExcelUseCase>();
        services.AddScoped<IGenerateExpensesReportPdfUseCase, GenerateExpensesReportPdfUseCase>();
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
    }
}
