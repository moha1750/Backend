using BackendTeamwork.Entities;

namespace BackendTeamwork.Databases
{
    public class DatabaseContext
    {
        public IEnumerable<Users> Userss;

        public DatabaseContext()
        {
            this.Userss =
            [
                new Users{
                    Id = new Guid(),
                    FirstName = "Almuhannad",
                    LastName = "Almhari",
                    Email = "Almuhannad@example.com",
                    Password = "12345",
                    Phone = "1234567890",
                    Role = "Admin",
                    Address = "null",
                    Wishlist = "null"
                }
            ];
        }

    }
}