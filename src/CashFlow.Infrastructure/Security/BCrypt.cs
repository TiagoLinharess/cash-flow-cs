using CashFlow.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infrastructure.Security;

internal class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        return BC.HashPassword(password);
    }

    public bool Verify(string password, string hashedPassword)
    {
        return BC.Verify(password, hashedPassword);
    }
}
