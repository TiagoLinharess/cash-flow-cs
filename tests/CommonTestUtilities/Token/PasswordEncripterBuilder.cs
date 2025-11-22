using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommonTestUtilities;

public class PasswordEncripterBuilder
{
    private readonly Mock<IPasswordEncripter> _mock;
    
    public PasswordEncripterBuilder()
    {
        _mock = new Mock<IPasswordEncripter>();
        
        _mock.Setup(model => model.Encrypt(It.IsAny<string>())).Returns("!fy87fh3y79f8hc83");
    }

    public PasswordEncripterBuilder Verify(string? password)
    {
        if (!string.IsNullOrWhiteSpace(password))
        {
            _mock.Setup(model => model.Verify(password, It.IsAny<string>())).Returns(true);
        }

        return this;
    }
    
    public IPasswordEncripter Build() => _mock.Object;
}