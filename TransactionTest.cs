using NUnit.Framework;


namespace AbcBankTest
{
    [TestFixture]
    public class TransactionTest
    {
        [Test]
        public void transaction()
        {
            Transaction t = new Transaction(5);
            Assert.AreEqual(true, t is Transaction);
        }
    }
}
