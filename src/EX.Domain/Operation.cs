using System;

namespace EX.Domain
{
    public abstract class Operation
    {
        protected Operation()
        {
        }

        protected Operation(string number, DateTimeOffset createdOn)
        {
            CreditCardNumber = number;
            CreatedOn = createdOn;
        }

        public int Id { get; private set; }

        public DateTimeOffset CreatedOn { get; private set; }

        public string CreditCardNumber { get; private set; }
    }
}