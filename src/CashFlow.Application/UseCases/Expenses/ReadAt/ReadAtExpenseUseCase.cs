using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.ReadAt;

internal class ReadAtExpenseUseCase : IReadAtExpenseUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;
    
    public ReadAtExpenseUseCase(IExpensesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<ResponseExpenseJson> Execute(long id)
    {
        var result = await _repository.ReadAt(id);
        
        if (result is not null)
        {
            return _mapper.Map<ResponseExpenseJson>(result);
        }
        
        throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
    }
}