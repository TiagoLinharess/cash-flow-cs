using Bogus;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterExpenseJsonBuilder
    {
        public static RequestRegisterExpenseJson Build()
        {
            return new Faker<RequestRegisterExpenseJson>()
                .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
                .RuleFor(r => r.Description, faker => faker.Lorem.Paragraph())
                .RuleFor(r => r.Date, faker => faker.Date.Past())
                .RuleFor(r => r.Amount, faker => faker.Finance.Amount(1, 1000))
                .RuleFor(r => r.PaymentType, faker => faker.PickRandom<CashFlow.Communication.Enums.PaymentType>());

        }
    }
}
