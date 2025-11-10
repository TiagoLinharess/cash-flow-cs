using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper;

internal class ExpenseMapping : Profile
{
    public ExpenseMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRegisterExpenseJson, Expense>();
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisteredExpenseJson>();
        CreateMap<Expense, ResponseExpenseShortJson>();
        CreateMap<Expense, ResponseExpenseJson>();
    }
}