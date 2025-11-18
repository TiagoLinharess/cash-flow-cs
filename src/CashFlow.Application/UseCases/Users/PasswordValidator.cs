using CashFlow.Exception;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace CashFlow.Application.UseCases.Users;

public partial class PasswordValidator<T> : PropertyValidator<T, string>
{
    private const string ERROR_ESSAGE_KEY = "ErrorMessage";
    public override string Name => "PasswordValidator";

    protected override string GetDefaultMessageTemplate(string errorCode)
    {
        return $"{{{ERROR_ESSAGE_KEY}}}";
    }

    public override bool IsValid(ValidationContext<T> context, string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            context.MessageFormatter.AppendArgument(ERROR_ESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        if (
            password.Length < 8 ||
            !UpperCaseLetter().IsMatch(password) ||
            !LowerCaseLetter().IsMatch(password) ||
            !Number().IsMatch(password) ||
            !EspecialSymbols().IsMatch(password))
        {
            context.MessageFormatter.AppendArgument(ERROR_ESSAGE_KEY, ResourceErrorMessages.INVALID_PASSWORD);
            return false;
        }

        return true;
    }

    [GeneratedRegex(@"[A-Z]+")]
    private static partial Regex UpperCaseLetter();

    [GeneratedRegex(@"[a-z]+")]
    private static partial Regex LowerCaseLetter();

    [GeneratedRegex(@"[0-9]+")]
    private static partial Regex Number();

    [GeneratedRegex(@"[\!\?\*\.\@]+")]
    private static partial Regex EspecialSymbols();
}
