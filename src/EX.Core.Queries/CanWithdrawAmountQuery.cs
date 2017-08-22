using MediatR;

namespace EX.Core.Queries
{
    public class CanWithdrawAmountQuery : IRequest<bool>
    {
        public CanWithdrawAmountQuery(string creditCardNumber, decimal amount)
        {
            CreditCardNumber = creditCardNumber;
            Amount = amount;
        }

        public string CreditCardNumber { get; private set; }

        public decimal Amount { get; private set; }
    }
}