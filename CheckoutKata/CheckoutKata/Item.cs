namespace CheckoutKata
{
    public class Item
    {
        public char Sku { get; set; }
        public int UnitPrice { get; set; }
        public int? DiscountPrice { get; set; }
        public int? DiscountQuanity { get; set; }
    }
}
