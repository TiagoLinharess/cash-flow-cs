using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.Read;

internal class ReadExpensesUseCase : IReadExpensesUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;
    
    public ReadExpensesUseCase(IExpensesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseExpensesJson> Execute()
    {
        var result = await _repository.Read();
        
        return new ResponseExpensesJson
        {
            Expenses = _mapper.Map<List<ResponseExpenseShortJson>>(result)
        };
    }
}