using MediatR;

namespace EX.Core.Queries
{
    public class ExistsNotBlockedCreditCardQuery : IRequest<bool>
    {
        public ExistsNotBlockedCreditCardQuery(string creditCardNumber)
        {
            CreditCardNumber = creditCardNumber;
        }

        public string CreditCardNumber { get; private set; }
    }
}