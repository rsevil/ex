using EX.Core.Queries;
using MediatR;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EX.Data.EF.QueryHandlers
{
    public class ExistsNotBlockedCreditCardQueryHandler : IAsyncRequestHandler<ExistsNotBlockedCreditCardQuery, bool>
    {
        private readonly DataContext _dbCtx;

        public ExistsNotBlockedCreditCardQueryHandler(DataContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public Task<bool> Handle(ExistsNotBlockedCreditCardQuery message)
        {
            return _dbCtx.CreditCards.AnyAsync(x => x.Number == message.CreditCardNumber && x.InvalidPinAttempts <= 4);
        }
    }
}