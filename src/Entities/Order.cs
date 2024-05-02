namespace BackendTeamwork.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public Guid PaymentId { get; set; }
        public Guid UserId { get; set; }
    }
}