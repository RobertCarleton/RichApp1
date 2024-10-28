namespace W2L2
{
    public class Ad
    {
        public int AdId { get; set; }
        public string AdName { get; set; }
        public string SellerName { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public float Price { get; set; }
        public string Type { get; set; }

        public Ad(int AdId, string AdName, string SellerName, string Description, string CategoryName, float Price, string Type)
        {
            this.AdId = AdId;
            this.AdName = AdName;
            this.SellerName = SellerName;
            this.Description = Description;
            this.CategoryName = CategoryName;
            this.Price = Price;
            this.Type = Type;
        }

    }
}
