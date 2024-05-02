namespace BackendTeamwork.Entities
{
    public class OrderStock
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public Guid StockId { get; set; }
    }
}