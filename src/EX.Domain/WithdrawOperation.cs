using System;

namespace EX.Domain
{
    public class WithdrawOperation : AmountMovementOperation
    {
        protected WithdrawOperation()
        {
        }

        public WithdrawOperation(string number, DateTimeOffset createdOn, decimal amount)
            :base(number, createdOn, amount)
        {
        }
    }
}