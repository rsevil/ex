using EX.Domain;
using System.Threading.Tasks;

namespace EX.Data.EF.Repositories
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly DataContext _dbCtx;

        public CreditCardRepository(DataContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public Task<CreditCard> FindByNumberAsync(string number)
        {
            return _dbCtx.CreditCards.FindAsync(number);
        }

        public void Update(CreditCard e)
        {
            _dbCtx.Entry(e).State = System.Data.Entity.EntityState.Modified;
        }
    }
}