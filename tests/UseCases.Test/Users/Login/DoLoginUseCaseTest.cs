using CashFlow.Application.UseCases.Users.Login;
using CashFlow.Domain.Entities;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommonTestUtilities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using Shouldly;

namespace UseCases.Test.Users.Login;

public class DoLoginUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var user = UserBuilder.Build();
        
        var request = RequestLoginJsonBuilder.Build();
        request.Email = user.Email;
        
        var useCase = CreateUseCase(user, request.Password);

        var result = await useCase.Execute(request);

        result.ShouldNotBeNull();
        result.Name.ShouldBe(user.Name);
        result.Token.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Error_User_Not_Found()
    {
        var user = UserBuilder.Build();
        var request = RequestLoginJsonBuilder.Build();
        
        var useCase = CreateUseCase(user, request.Password);

        var act = async () => await useCase.Execute(request);
        
        var exception = await Should.ThrowAsync<InvalidLoginException>(act);
        
        exception.GetErrors()[0].ShouldBe(ResourceErrorMessages.INVALID_LOGIN);
        exception.GetErrors().Count.ShouldBe(1);
    }
    
    [Fact]
    public async Task Error_Password_Not_Match()
    {
        var user = UserBuilder.Build();
        
        var request = RequestLoginJsonBuilder.Build();
        request.Email = user.Email;
        
        var useCase = CreateUseCase(user);

        var act = async () => await useCase.Execute(request);
        
        var exception = await Should.ThrowAsync<InvalidLoginException>(act);
        
        exception.GetErrors()[0].ShouldBe(ResourceErrorMessages.INVALID_LOGIN);
        exception.GetErrors().Count.ShouldBe(1);
    }

    private DoLoginUseCase CreateUseCase(User user, string? password = null)
    {
        var passwordEncripter = new PasswordEncripterBuilder().Verify(password).Build();
        var tokenGenerator = JwtTokenGeneratorBuilder.Build();
        var readOnlyRepository = new UserReadOnlyRepositoryBuilder().GetUserByEmail(user);
        
        return new DoLoginUseCase(readOnlyRepository.Build(), passwordEncripter, tokenGenerator);
    }
}