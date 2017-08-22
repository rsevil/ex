using System;

namespace EX.Domain.Exceptions
{
    public class CannotWithdrawAmountException : Exception
    {
        public CannotWithdrawAmountException(decimal amount, decimal balance) 
            : base($"Cannot withdraw {amount} from card, current balance is {balance}")
        {
        }
    }
}