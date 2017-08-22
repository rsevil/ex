using EX.Core.Commands;
using EX.Data;
using MediatR;
using System.Threading.Tasks;

namespace EX.Core.CommandHandlers
{
    public class LogBalanceCommandHandler : IAsyncRequestHandler<LogBalanceCommand>
    {
        private readonly ICreditCardRepository _creditCards;

        public LogBalanceCommandHandler(
            ICreditCardRepository creditCards)
        {
            _creditCards = creditCards;
        }

        public async Task Handle(LogBalanceCommand message)
        {
            var card = await _creditCards.FindByNumberAsync(message.CreditCardNumber);
            card.LogBalance(message.CreatedOn);
            _creditCards.Update(card);
        }
    }
}