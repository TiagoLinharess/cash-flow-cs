using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Create
{
    internal class CreateExpenseUseCase : ICreateExpenseUseCase
    {
        private readonly IExpensesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateExpenseUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public ResponseRegisteredExpenseJson Execute(RequestRegisterExpenseJson request)
        {
            Validate(request);

            var entity = new Domain.Entities.Expense
            {
                Title = request.Title,
                Description = request.Description,
                Date = request.Date,
                Amount = request.Amount,
                PaymentType = (Domain.Enums.PaymentType)request.PaymentType
            };

            _repository.Add(entity);
            _unitOfWork.Commit();

            return new ResponseRegisteredExpenseJson
            {
                Title = request.Title
            };
        }

        private void Validate(RequestRegisterExpenseJson request)
        {
            var validator = new RegisterExpenseValidator();
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
