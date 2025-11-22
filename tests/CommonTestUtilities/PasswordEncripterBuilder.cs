using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommonTestUtilities;

public class PasswordEncripterBuilder
{
    public static IPasswordEncripter Build()
    {
        var mock = new Mock<IPasswordEncripter>();
        
        mock.Setup(model => model.Encrypt(It.IsAny<string>())).Returns("!fy87fh3y79f8hc83");
        
        return mock.Object;
    }
}