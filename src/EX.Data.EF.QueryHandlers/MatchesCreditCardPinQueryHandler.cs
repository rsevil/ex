using EX.Core.Queries;
using MediatR;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EX.Data.EF.QueryHandlers
{
    public class MatchesCreditCardPinQueryHandler : IAsyncRequestHandler<MatchesCreditCardPinQuery, bool>
    {
        private readonly DataContext _dbCtx;

        public MatchesCreditCardPinQueryHandler(DataContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public Task<bool> Handle(MatchesCreditCardPinQuery message)
        {
            return _dbCtx.CreditCards.AnyAsync(x => x.Number == message.CreditCardNumber && x.Pin == message.Pin);
        }
    }
}