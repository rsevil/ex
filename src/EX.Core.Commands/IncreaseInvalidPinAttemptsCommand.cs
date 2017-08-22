using MediatR;

namespace EX.Core.Commands
{
    public class IncreaseInvalidPinAttemptsCommand : IRequest
    {
        public IncreaseInvalidPinAttemptsCommand(string creditCardNumber)
        {
            CreditCardNumber = creditCardNumber;
        }

        public string CreditCardNumber { get; private set; }
    }
}