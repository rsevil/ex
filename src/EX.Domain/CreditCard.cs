using EX.Domain.Exceptions;
using System;
using System.Collections.Generic;

namespace EX.Domain
{
    public class CreditCard
    {
        protected CreditCard()
        {
            Operations = new List<Operation>();
        }

        public string Number { get; private set; }

        public string Pin { get; private set; }

        public DateTimeOffset ValidFrom { get; private set; }

        public DateTimeOffset DueOn { get; private set; }

        public int InvalidPinAttempts { get; private set; }

        public decimal Balance { get; private set; }

        // EF Leaks Collection Mutability
        public virtual ICollection<Operation> Operations { get; private set; }

        public void Withdraw(DateTimeOffset createdOn, decimal amount)
        {
            if (Balance - amount < 0)
                throw new CannotWithdrawAmountException(amount, Balance);

            Balance -= amount;

            Operations.Add(
                new WithdrawOperation(Number, createdOn, amount));
        }

        public void LogBalance(DateTimeOffset createdOn)
        {
            Operations.Add(
                new BalanceOperation(Number, createdOn));
        }

        public void IncreaseInvalidPinAttempts()
        {
            InvalidPinAttempts++;
        }
    }
}