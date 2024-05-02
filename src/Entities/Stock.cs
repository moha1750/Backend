namespace BackendTeamwork.Entities
{
    public class Stock
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public Guid ProductId { get; set; }

    }
}