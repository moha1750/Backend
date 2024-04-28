using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class UserRepository : IUserRepository
    {
        private IEnumerable<User> _users;

        public UserRepository()
        {
            _users = new DatabaseContext().Users;
        }

        public IEnumerable<User> FindMany()
        {
            return _users;
        }
        public User? FindOne(Guid id)
        {
            return _users.FirstOrDefault(user => user.Id == id);
        }

        public User CreateOne(User newUser)
        {
            _users = _users.Append(newUser);

            _users.ToList().ForEach(user =>
            {
                Console.WriteLine($"{user.Email}");
            });

            return newUser;
        }

    }
}