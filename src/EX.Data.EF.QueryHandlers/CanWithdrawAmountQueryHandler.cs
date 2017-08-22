using EX.Core.Queries;
using MediatR;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EX.Data.EF.QueryHandlers
{
    public class CanWithdrawAmountQueryHandler : IAsyncRequestHandler<CanWithdrawAmountQuery, bool>
    {
        private readonly DataContext _dbCtx;

        public CanWithdrawAmountQueryHandler(DataContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public Task<bool> Handle(CanWithdrawAmountQuery message)
        {
            return _dbCtx.CreditCards.AnyAsync(x => x.Number == message.CreditCardNumber && x.Balance - message.Amount >= 0);
        }
    }
}