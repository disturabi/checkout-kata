namespace CheckoutKata
{
    public class Item
    {
        public string Sku { get; set; }
        public int UnitPrice { get; set; }
        public int? DiscountPrice { get; set; }
        public int? DiscountQuanity { get; set; }
    }
}
