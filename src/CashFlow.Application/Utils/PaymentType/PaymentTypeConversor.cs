using CashFlow.Domain.Resources.PaymentType;

namespace CashFlow.Application.Utils.PaymentType;

internal class PaymentTypeConversor
{
    public static string Execute(int paymentType)
    {
        return paymentType switch
        {
            0 => PaymentTypeResources.CASH,
            1 => PaymentTypeResources.CREDIT_CARD,
            2 => PaymentTypeResources.DEBIT_CARD,
            3 => PaymentTypeResources.ELETRONIC_TRANSFER,
            _ => string.Empty
        };
    }
}
