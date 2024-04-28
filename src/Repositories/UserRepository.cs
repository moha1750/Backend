using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<User> FindMany()
        {
            return new DatabaseContext().Users;
        }
        public User? FindOne(Guid id)
        {
            return new DatabaseContext().Users.FirstOrDefault(user => user.Id == id);
        }

    }
}