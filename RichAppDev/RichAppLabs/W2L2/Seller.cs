namespace W2L2
{
    public class Seller
    {
        public int SellerId { get; set; }  
        public string SellerName { get; set; }

        public Seller(int SellerId, string SellerName)
        {
            this.SellerId = SellerId;
            this.SellerName = SellerName;
        }

    }
}
