using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Tokens;
using Moq;

namespace CommonTestUtilities.Token;

public class JwtTokenGeneratorBuilder
{
    public static IAccessTokenGenerator Build()
    {
        var mock = new Mock<IAccessTokenGenerator>();

        mock.Setup(accessTokenGenerator => accessTokenGenerator.Generate(It.IsAny<User>())).Returns("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRpYWdvIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc2lkIjoiNzY4N2JkOWEtNDI1MC00ZGNkLWJkNmUtY2E1MWNiNmRjMzlmIiwibmJmIjoxNzYzNzUwODE2LCJleHAiOjE3NjM4MTA4MTYsImlhdCI6MTc2Mzc1MDgxNn0.sFN91yB22auuMrMX0x6FAgMLs-HhtKg39OfdbuNf7UE");
        
        return mock.Object;
    }
}