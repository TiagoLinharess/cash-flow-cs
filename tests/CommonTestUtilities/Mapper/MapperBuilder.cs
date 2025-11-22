using AutoMapper;
using CashFlow.Application.AutoMapper;
using Microsoft.Extensions.Logging.Abstractions;

namespace CommonTestUtilities.Mapper;

public class MapperBuilder
{
    public static IMapper Build()
    {
        var mapper = new MapperConfiguration(config =>
        {
            config.AddProfile(new UserMapping());
            config.AddProfile(new ExpenseMapping());
        }, new NullLoggerFactory());
        
        return mapper.CreateMapper();
    }
}