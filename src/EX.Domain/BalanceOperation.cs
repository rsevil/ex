using System;

namespace EX.Domain
{
    public class BalanceOperation : Operation
    {
        protected BalanceOperation()
        {
        }

        public BalanceOperation(string number, DateTimeOffset createdOn)
            : base(number, createdOn)
        {
        }
    }
}