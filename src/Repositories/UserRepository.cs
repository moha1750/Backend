using BackendTeamwork.Abstractions;
using BackendTeamwork.Databases;
using BackendTeamwork.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTeamwork.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbSet<User> _users;
        private DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _users = databaseContext.Users;
            _databaseContext = databaseContext;
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
            _users.Add(newUser);
            _databaseContext.SaveChanges();
            return newUser;
        }

        public User UpdateOne(User updatedUser)
        {
            User? oldData = this.FindOne(updatedUser.Id);
            oldData = updatedUser;
            return oldData;
        }

        public bool DeleteOne(Guid id)
        {
            if (this.FindOne(id) is not null)
            {
                // _users = _users.Where(user => user.Id != id);
                return true;
            }
            return false;
        }

        public bool DeleteMany(IEnumerable<Guid> ids)
        {
            foreach (Guid id in ids)
            {
                if (_users.FirstOrDefault(user => user.Id == id) is null)
                {
                    return false;
                }
            }

            foreach (Guid id in ids)
            {
                // _users = _users.Where(user => user.Id != id);
            }

            _users.ToList().ForEach(user =>
            {
                Console.WriteLine($"{user.Id}");
            });

            return true;
        }

    }
}