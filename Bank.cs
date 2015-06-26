using System;
using System.Collections.Generic;

namespace AbcBankTest
{

    public class Bank
    {
        private List<Customer> customers;

        public Bank()
        {
            customers = new List<Customer>();
        }


        public void addCustomer(Customer customer)
        {
            customers.Add(customer);
        }


        public String customerSummary()
        {
            String summary = "Customer Summary";
            foreach (Customer c in customers)
                summary += "\n - " + c.getName() + " (" + format(c.getNumberOfAccounts(), "account") + ")";
            return summary;
        }

        private String format(int number, String word)
        {
            return number + " " + (number == 1 ? word : word + "s");
        }


        public double totalInterestPaid()
        {
            double total = 0;
            foreach (Customer c in customers)
                total += c.totalInterestEarned();
            return total;
        }


        public String getFirstCustomer()
        {
            try
            {
                customers = null;
                return customers[0].getName();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "Error";
            }
        }
    }
}
