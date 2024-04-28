using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IUserRepository
    {
        public IEnumerable<User> FindMany();
        public User? FindOne(Guid id);
    }
}