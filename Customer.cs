using System;
using System.Collections.Generic;

namespace AbcBankTest
{

    public class Customer
    {
        private String name;
        private List<Account> accounts;


        public Customer(String name)
        {
            this.name = name;
            this.accounts = new List<Account>();
        }


        public String getName()
        {
            return name;
        }


        public Customer openAccount(Account account)
        {
            accounts.Add(account);
            return this;
        }


        public int getNumberOfAccounts()
        {
            return accounts.Count;
        }


        public double totalInterestEarned()
        {
            double total = 0;
            foreach (Account a in accounts)
                total += a.interestEarned();
            return total;
        }


        public String getStatement()
        {
            String statement = null;
            statement = "Statement for " + name + "\n";
            double total = 0.0;
            foreach (Account a in accounts)
            {
                statement += "\n" + statementForAccount(a) + "\n";
                total += a.sumTransactions();
            }
            statement += "\nTotal In All Accounts " + toDollars(total);
            return statement;
        }


        private String statementForAccount(Account a)
        {
            String s = "";

            switch (a.getAccountType())
            {
                case Account.CHECKING:
                    s += "Checking Account\n";
                    break;
                case Account.SAVINGS:
                    s += "Savings Account\n";
                    break;
                case Account.MAXI_SAVINGS:
                    s += "Maxi Savings Account\n";
                    break;
            }

            double total = 0.0;
            foreach (Transaction t in a.transactions)
            {
                s += "  " + (t.amount < 0 ? "withdrawal" : "deposit") + " " + toDollars(t.amount) + "\n";
                total += t.amount;
            }
            s += "Total " + toDollars(total);
            return s;
        }


        private String toDollars(double d)
        {
            return String.Format("${0:N2}", Math.Abs(d));
        }
    }
}
