namespace CheckoutKata
{
    public class Checkout : ICheckout
    {
        private List<char> _skus;
        private List<Item> _items;

        public Checkout(List<Item> items)
        {
            _skus = new List<char>();
            _items = items;
        }

        public void Scan(string items)
        {
            if (!string.IsNullOrEmpty(items))
            {
                var skus = items.ToCharArray();
                foreach (char sku in skus)
                {
                    if (_items.Any(item => item.Sku == sku))
                    {
                        _skus.Add(sku);
                    } 
                    else
                    {
                        throw new KeyNotFoundException($"The SKU '{sku}' does not exist");
                    }               
                }
            }
            else
            {
                throw new ArgumentNullException("List of SKUs cannot be null or empty");
            }
        }

        public int GetTotalPrice()
        {
            var discountTotal = 0;
            var nonDiscountTotal = 0;

            var total = 0;

            foreach (var item in _items)
            {
                var itemQuantity = _skus.Count(sku => sku == item.Sku);

                if (item.DiscountQuanity.HasValue && item.DiscountPrice.HasValue)
                {
                    if (itemQuantity >= item.DiscountQuanity.Value)
                    {
                        // Within the string of SKUs, we need to determine qualifications of discounts
                        // Given the example string: AAAABB where 3xA and 2xB qualify for discounts
                        // We need to find the amounts for AAA A BB respectively
                        var discountQuantity = itemQuantity / item.DiscountQuanity.Value;
                        var nonDiscountQuantity = itemQuantity % item.DiscountQuanity.Value;

                        discountTotal = (int)(discountQuantity * item.DiscountPrice);
                        nonDiscountTotal = nonDiscountQuantity * item.UnitPrice;

                        total += discountTotal + nonDiscountTotal;                    
                    }
                    else
                    {
                        total += itemQuantity * item.UnitPrice;
                    }
                }
                else
                {
                    total += itemQuantity * item.UnitPrice;
                }
            }

            return total;
        }
    }
}
