namespace BackendTeamwork.Entities
{
    public class Address
    {
        public Address(Guid id, string city, string zip, string addressLine, Guid userId)
        {
            Id = id;
            City = city;
            Zip = zip;
            AddressLine = addressLine;
            UserId = userId;
        }

        public Guid Id { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string AddressLine { get; set; }
        public Guid UserId { get; set; }
    }
}