namespace API_Project.Data.Entities
{
    public class Order
    {
        public string  OrderId { get; set; }= Guid.NewGuid().ToString();
        public string  CustomerId { get; set; }
        public string MyProperty { get; set; }
    }
}
