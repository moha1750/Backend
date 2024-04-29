using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IUserService
    {
        public IEnumerable<User> FindMany();
        public User? FindOne(Guid id);

        public User CreateOne(User newUser);
        public User UpdateOne(User UpdatedUser);
        public bool DeleteOne(Guid id);
        public bool DeleteMany(IEnumerable<Guid> ids);

    }
}