using MediatR;
using System;

namespace EX.Core.Commands
{
    public class WithdrawCommand : IRequest
    {
        public WithdrawCommand(string name, DateTimeOffset createdOn, decimal amount)
        {
            CreditCardNumber = name;
            CreatedOn = createdOn;
            Amount = amount;
        }

        public string CreditCardNumber { get; private set; }

        public DateTimeOffset CreatedOn { get; private set; }

        public decimal Amount { get; private set; }
    }
}