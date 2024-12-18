namespace CheckoutKata.Tests
{
    public class CheckoutTests
    {
        private Checkout _checkout;

        [SetUp]
        public void Setup()
        {
            _checkout = new Checkout(new List<Item>
            {
                new Item { Sku = 'A', UnitPrice = 50, DiscountQuanity = 3, DiscountPrice = 130 },
                new Item { Sku = 'B', UnitPrice = 30, DiscountQuanity = 2, DiscountPrice = 45 },
                new Item { Sku = 'C', UnitPrice = 20 },
                new Item { Sku = 'D', UnitPrice = 15 },
            });
        }

        
        [TestCase("A")]
        public void Scan_Sku(string scanString)
        {
            _checkout.Scan(scanString);
        }

        [TestCase("Z")]
        public void Scan_Sku_ThrowsKeyNotFoundException(string scanString)
        {
            var expectedMessage = "The SKU 'Z' does not exist";
            var ex = Assert.Throws<KeyNotFoundException>(() => _checkout.Scan(scanString));

            Assert.IsTrue(ex.Message == expectedMessage);
        }

        [TestCase("")]
        public void Scan_Sku_ThrowsArgumentNullException(string scanString)
        {
            var expectedMessage = "List of SKUs cannot be null or empty";
            var ex = Assert.Throws<ArgumentNullException>(() => _checkout.Scan(scanString));

            Assert.IsTrue(ex.ParamName == expectedMessage);
        }

        [TestCase("A", 50)]
        [TestCase("AB", 80)]
        [TestCase("ABCD", 115)]
        public void GetTotalPrice_NoOffer(string scanString, int expectedTotal)
        {
            _checkout.Scan(scanString);

            var total = _checkout.GetTotalPrice();
            Assert.That(total == expectedTotal);
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