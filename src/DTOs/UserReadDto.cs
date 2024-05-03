namespace BackendTeamwork.DTOs
{
    public class UserReadDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public Guid Address { get; set; }
        public Guid Wishlist { get; set; }
    }
}