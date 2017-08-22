using EX.Core.Queries;
using EX.Core.Queries.DTO;
using EX.Domain;
using MediatR;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EX.Data.EF.QueryHandlers
{
    public class BalanceQueryHandler : IAsyncRequestHandler<BalanceQuery, Balance>
    {
        private readonly DataContext _dtCtx;

        public BalanceQueryHandler(DataContext dtCtx)
        {
            _dtCtx = dtCtx;
        }

        public Task<Balance> Handle(BalanceQuery message)
        {
            return _dtCtx.CreditCards
                .Select(x => new Balance()
                {
                    CreditCardNumber = x.Number,
                    ValidFrom = x.ValidFrom,
                    DueOn = x.DueOn,
                    Amount = x.Balance,
                    WithdrawnAmount = x.Operations.OfType<WithdrawOperation>().Sum(y => y.Amount)
                })
                .SingleAsync(x => x.CreditCardNumber == message.CreditCardNumber);
        }
    }
}