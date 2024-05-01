namespace BackendTeamwork.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string AddressLine { get; set; }
        public Guid UserId { get; set; }
    }
}