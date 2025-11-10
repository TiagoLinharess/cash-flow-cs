using CashFlow.Application.UseCases.Expenses;
using CashFlow.Communication.Enums;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using Shouldly;

namespace Validators.Tests.Expenses.Register
{
    public class ExpenseValidatorTests
    {
        [Fact]
        public void Success()
        {
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.ShouldBeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public void Error_Title_Invalid(string title)
        {
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Title = title;

            var result = validator.Validate(request);

            result.IsValid.ShouldBeFalse();
            result.Errors.Count.ShouldBe(1);
            result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.TITLE_REQUIRED);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Error_Amount_Invalid(decimal amount)
        {
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.Amount = amount;

            var result = validator.Validate(request);

            result.IsValid.ShouldBeFalse();
            result.Errors.Count.ShouldBe(1);
            result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        }

        [Fact]
        public void Error_Payment_Type_Invalid()
        {
            var validator = new ExpenseValidator();
            var request = RequestRegisterExpenseJsonBuilder.Build();
            request.PaymentType = (PaymentType)999;

            var result = validator.Validate(request);

            result.IsValid.ShouldBeFalse();
            result.Errors.Count.ShouldBe(1);
            result.Errors.ShouldContain(e => e.ErrorMessage == ResourceErrorMessages.INVALID_PAYMENT_TYPE);
        }
    }
}
