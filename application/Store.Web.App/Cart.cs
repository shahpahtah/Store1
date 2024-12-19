namespace Store.Web.App
{
    public class Cart
    {
        public int OrderId { get; }
        public int TotalCount { get; set; }
        public decimal TotalPrice { get;  }
        public Cart(int orderid,int totalcount,decimal totalprice) 
        {
            OrderId= orderid;
            TotalCount= totalcount;
            TotalPrice= totalprice;
        }
    }
}
