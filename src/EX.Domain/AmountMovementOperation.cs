using System;

namespace EX.Domain
{
    public abstract class AmountMovementOperation : Operation
    {
        protected AmountMovementOperation()
            :base()
        {
        }

        protected AmountMovementOperation(string number, DateTimeOffset createdOn, decimal amount)
            :base(number, createdOn)
        {
            Amount = amount;
        }

        public decimal Amount { get; private set; }
    }
}