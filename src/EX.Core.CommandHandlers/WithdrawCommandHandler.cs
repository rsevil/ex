using EX.Core.Commands;
using EX.Data;
using MediatR;
using System.Threading.Tasks;

namespace EX.Core.CommandHandlers
{
    public class WithdrawCommandHandler : IAsyncRequestHandler<WithdrawCommand>
    {
        private readonly ICreditCardRepository _creditCards;

        public WithdrawCommandHandler(ICreditCardRepository creditCards)
        {
            _creditCards = creditCards;
        }

        public async Task Handle(WithdrawCommand message)
        {
            var card = await _creditCards.FindByNumberAsync(message.CreditCardNumber);
            card.Withdraw(message.CreatedOn, message.Amount);
            _creditCards.Update(card);
        }
    }
}