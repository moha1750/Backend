using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IUserService
    {
        public IEnumerable<User> FindMany();
        public User? FindOne(Guid id);

        public User CreateOne(User newUser);
        // public User UpdateOne(User UpdatedUser);
        // public void DeleteOne(Guid id);
        // public void DeleteMany(IEnumerable<Guid> ids);

    }
}