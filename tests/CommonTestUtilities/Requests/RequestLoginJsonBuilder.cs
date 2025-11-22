using Bogus;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestLoginJsonBuilder
{
    public static RequestLoginJson Build()
    {
        return new Faker<RequestLoginJson>()
            .RuleFor(o => o.Email, f => f.Internet.Email())
            .RuleFor(o => o.Password, f => f.Internet.Password(prefix: "!Aa1"));
    }
}