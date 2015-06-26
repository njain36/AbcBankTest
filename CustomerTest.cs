using NUnit.Framework;


namespace AbcBankTest
{
    [TestFixture]
    public class CustomerTest
    {

        [Test] //Test customer statement generation
        public void testApp()
        {

            Account checkingAccount = new Account(Account.CHECKING);
            Account savingsAccount = new Account(Account.SAVINGS);

            Customer Steve = new Customer("Steve").openAccount(checkingAccount).openAccount(savingsAccount);

            checkingAccount.deposit(100.0);
            savingsAccount.deposit(4000.0);
            savingsAccount.withdraw(200.0);

            Assert.AreEqual("Statement for Steve\n" +
                    "\n" +
                    "Checking Account\n" +
                    "  deposit $100.00\n" +
                    "Total $100.00\n" +
                    "\n" +
                    "Savings Account\n" +
                    "  deposit $4,000.00\n" +
                    "  withdrawal $200.00\n" +
                    "Total $3,800.00\n" +
                    "\n" +
                    "Total In All Accounts $3,900.00", Steve.getStatement());
        }

        [Test]
        public void testOneAccount()
        {
            Customer Mike = new Customer("Mike").openAccount(new Account(Account.SAVINGS));
            Assert.AreEqual(1, Mike.getNumberOfAccounts());
        }

        [Test]
        public void testTwoAccount()
        {
            Customer Mike = new Customer("Mike")
                    .openAccount(new Account(Account.SAVINGS));
            Mike.openAccount(new Account(Account.CHECKING));
            Assert.AreEqual(2, Mike.getNumberOfAccounts());
        }

        [Ignore]
        public void testThreeAcounts()
        {
            Customer Mike = new Customer("Mike")
                    .openAccount(new Account(Account.SAVINGS));
            Mike.openAccount(new Account(Account.CHECKING));
            Assert.AreEqual(3, Mike.getNumberOfAccounts());
        }
    }
}
