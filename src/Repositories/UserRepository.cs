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
            _users = databaseContext.User;
            _databaseContext = databaseContext;
        }


        public IEnumerable<User> FindMany()
        {
            return _users;
        }
        public async Task<User?> FindOne(Guid id)
        {
            return await _users.AsNoTracking().FirstOrDefaultAsync(user => user.Id == id);
        }

        public async Task<User> CreateOne(User newUser)
        {
            await _users.AddAsync(newUser);
            await _databaseContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> UpdateOne(User updatedUser)
        {
            _users.Update(updatedUser);
            await _databaseContext.SaveChangesAsync();
            return updatedUser;
        }

        public async Task<User> DeleteOne(User deletedUser)
        {
            _users.Remove(deletedUser);
            await _databaseContext.SaveChangesAsync();
            return deletedUser;
        }
    }
}