using System;

namespace AbcBankTest
{
    public class Transaction
    {
        public readonly double amount;

        private DateTime transactionDate;

        public Transaction(double amount)
        {
            this.amount = amount;
            this.transactionDate = DateTime.Now;
        }

    }
}
