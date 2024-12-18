namespace CheckoutKata.Tests
{
    public class CheckoutTests
    {
        private List<Item> _items;

        [SetUp]
        public void Setup()
        {
            _items = new List<Item> 
            {
                new Item { Sku = "A", UnitPrice = 50, DiscountQuanity = 3, DiscountPrice = 130 },
                new Item { Sku = "B", UnitPrice = 30, DiscountQuanity = 2, DiscountPrice = 45 },
                new Item { Sku = "C", UnitPrice = 20 },
                new Item { Sku = "D", UnitPrice = 15 },
            };
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