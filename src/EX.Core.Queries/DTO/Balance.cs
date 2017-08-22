using System;

namespace EX.Core.Queries.DTO
{
    public class Balance
    {
        // EF 6 Limitation, cannot call ctors on Exprs
        //public Balance(
        //    string creditCardNumber, 
        //    DateTimeOffset validFrom, 
        //    DateTimeOffset dueOn,
        //    decimal amount,
        //    decimal withdrawnAmount)
        //{
        //    CreditCardNumber = creditCardNumber;
        //    ValidFrom = validFrom;
        //    DueOn = dueOn;
        //    Amount = amount;
        //    WithdrawnAmount = withdrawnAmount;
        //}

        public string CreditCardNumber { get; set; }

        public DateTimeOffset ValidFrom { get; set; }

        public DateTimeOffset DueOn { get; set; }

        public decimal Amount { get; set; }

        public decimal WithdrawnAmount { get; set; }
    }
}
