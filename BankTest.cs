using NUnit.Framework;


namespace AbcBankTest
{
    [TestFixture]
    public class BankTest
    {
        private static readonly double DOUBLE_DELTA = 1e-15;

        [Test]
        public void customerSummary()
        {
            Bank bank = new Bank();
            Customer Bob = new Customer("Bob");
            Bob.openAccount(new Account(Account.CHECKING));
            bank.addCustomer(Bob);

            Assert.AreEqual("Customer Summary\n - Bob (1 account)", bank.customerSummary());
        }

        [Test]
        public void checkingAccount()
        {
            Bank bank = new Bank();
            Account checkingAccount = new Account(Account.CHECKING);
            Customer Steve = new Customer("Steve").openAccount(checkingAccount);
            bank.addCustomer(Steve);

            checkingAccount.deposit(100.0);

            Assert.AreEqual(0.1, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void savings_account()
        {
            Bank bank = new Bank();
            Account checkingAccount = new Account(Account.SAVINGS);
            bank.addCustomer(new Customer("Steve").openAccount(checkingAccount));

            checkingAccount.deposit(1500.0);

            Assert.AreEqual(2.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

        [Test]
        public void maxi_savings_account()
        {
            Bank bank = new Bank();
            Account checkingAccount = new Account(Account.MAXI_SAVINGS);
            bank.addCustomer(new Customer("Steve").openAccount(checkingAccount));

            checkingAccount.deposit(3000.0);

            Assert.AreEqual(170.0, bank.totalInterestPaid(), DOUBLE_DELTA);
        }

    }
}
