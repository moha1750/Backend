using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IUserRepository
    {
        public IEnumerable<User> FindMany(int limit, int offset);
        public Task<User?> FindOne(Guid id);

        public Task<User> SignUp(User newUser);
        public Task<User?> FindOneByEmail(string email);
        public Task<User> UpdateOne(User UpdatedUser);
        public Task<User> DeleteOne(User deletedUser);
    }
}