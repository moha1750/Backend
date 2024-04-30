namespace BackendTeamwork.Entities
{
    public class OrderStock
    {
        public OrderStock(Guid orderId, int quantity, Guid stockId)
        {
            OrderId = orderId;
            Quantity = quantity;
            StockId = stockId;
        }

        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public Guid StockId { get; set; }
    }
}