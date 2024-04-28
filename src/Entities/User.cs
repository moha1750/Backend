namespace BackendTeamwork.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public Guid Address { get; set; }
        public Guid Wishlist { get; set; }

        public User(Guid id, string firstName, string lastName, string email, string password, string phone, string role, Guid address, Guid wishlist)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
            Role = role;
            Address = address;
            Wishlist = wishlist;
        }
    }
}