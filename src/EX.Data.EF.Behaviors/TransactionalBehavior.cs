using MediatR.Pipeline;
using System.Threading.Tasks;

namespace EX.Data.EF.Behaviors
{
    public class TransactionalBehavior<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly DataContext _dbCtx;

        public TransactionalBehavior(DataContext dbCtx)
        {
            _dbCtx = dbCtx;
        }

        public Task Process(TRequest request, TResponse response)
        {
            if (typeof(TRequest).Name.EndsWith("Command"))
            {
                return _dbCtx.SaveChangesAsync();
            }

            return Task.CompletedTask;
        }
    }
}