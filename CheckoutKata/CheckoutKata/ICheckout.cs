namespace CheckoutKata
{
    internal interface ICheckout
    {
        void Scan(string items);
        int GetTotalPrice();
    }
}
