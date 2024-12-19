namespace Store.Web.App
{
    public class OrderModel
    {
        public int Id { get; set; }
        public List<OrderItemModel> items { get; set; } = new List<OrderItemModel>(); 
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; } 
        public Dictionary<string,string> Errors= new Dictionary<string,string>();
        public string CellPhone { get; set; }
        public string Cellphone { get; set; }
        public string deliveryDescription { get; set; }
        public string paymentDescription { get; set; }
    }
}
