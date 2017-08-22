using MediatR;

namespace EX.Core.Queries
{
    public class MatchesCreditCardPinQuery : IRequest<bool>
    {
        public MatchesCreditCardPinQuery(string creditCardNumber, string pin)
        {
            CreditCardNumber = creditCardNumber;
            Pin = pin;
        }

        public string CreditCardNumber { get; private set; }

        public string Pin { get; private set; }
    }
}