using EX.Domain;
using System.Threading.Tasks;

namespace EX.Data
{
    public interface ICreditCardRepository
    {
        Task<CreditCard> FindByNumberAsync(string number);

        void Update(CreditCard e);
    }
}