namespace CashFlow.Application.UseCases.Reports;

public interface IGenerateExpensesReportExcelUseCase
{
    Task<byte[]> Execute(DateOnly month);
}