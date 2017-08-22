using EX.Core.Commands;
using EX.Data;
using MediatR;
using System.Threading.Tasks;

namespace EX.Core.CommandHandlers
{
    public class IncreaseInvalidPinAttemptsCommandHandler : IAsyncRequestHandler<IncreaseInvalidPinAttemptsCommand>
    {
        private readonly ICreditCardRepository _creditCards;

        public IncreaseInvalidPinAttemptsCommandHandler(
            ICreditCardRepository creditCards)
        {
            _creditCards = creditCards;
        }

        public async Task Handle(IncreaseInvalidPinAttemptsCommand message)
        {
            var card = await _creditCards.FindByNumberAsync(message.CreditCardNumber);

            card.IncreaseInvalidPinAttempts();

            _creditCards.Update(card);
        }
    }
}