using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IUserRepository
    {
        public IEnumerable<User> FindMany();
        public Task<User?> FindOne(Guid id);

        public Task<User> CreateOne(User newUser);
        public Task<User> UpdateOne(User UpdatedUser);
        public Task<User> DeleteOne(User deletedUser);
    }
}