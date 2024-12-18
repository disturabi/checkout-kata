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
            throw new NotImplementedException();
        }
    }
}
