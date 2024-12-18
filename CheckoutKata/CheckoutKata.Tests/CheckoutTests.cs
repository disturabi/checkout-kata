namespace CheckoutKata.Tests
{
    public class CheckoutTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("", 0)]
        [TestCase("Z", 0)]
        [TestCase("A", 50)]
        public void Scan_Sku(string scanString, int total)
        {
            Assert.Fail();
        }

        [TestCase("A", 50)]
        [TestCase("AB", 80)]
        [TestCase("ABCD", 115)]
        public void GetTotalPrice_NoOffer(string scanString, int total)
        {
            Assert.Fail();
        }

        [TestCase("AAA", 130)]
        [TestCase("AAABB", 175)]
        public void GetTotalPrice_Offer(string scanString, int total)
        {
            Assert.Fail();
        }

        [TestCase("AAAB", 160)]
        [TestCase("ABB", 95)]
        [TestCase("AAABBCD", 210)]
        public void GetTotalPrice_OfferPlusNoOffer(string scanString, int total)
        {
            Assert.Fail();
        }

        [TestCase("AAABBCD", 210)]
        [TestCase("AAAAAA", 260)]
        [TestCase("BBBBAAA", 305)]
        public void GetTotalPrice_MultipleOffer(string scanString, int total)
        {
            Assert.Fail();
        }
    }
}