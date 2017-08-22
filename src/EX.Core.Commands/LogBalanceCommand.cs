using MediatR;
using System;

namespace EX.Core.Commands
{
    public class LogBalanceCommand : IRequest
    {
        public LogBalanceCommand(string creditCardNumber, DateTimeOffset createdOn)
        {
            CreditCardNumber = creditCardNumber;
            CreatedOn = createdOn;
        }

        public DateTimeOffset CreatedOn { get; private set; }

        public string CreditCardNumber { get; private set; }
    }
}