namespace W4L1P2
{
    public class Category
    {
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }

        public Category (string CategoryName, int CategoryID)
        {
            this.CategoryName = CategoryName;
            this.CategoryID = CategoryID;
        }
    }
}
