using EX.Core.Queries.DTO;
using MediatR;

namespace EX.Core.Queries
{
    public class BalanceQuery : IRequest<Balance>
    {
        public BalanceQuery(string creditCardNumber)
        {
            CreditCardNumber = creditCardNumber;
        }

        public string CreditCardNumber { get; private set; }
    }
}