using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IUserService
    {
        public IEnumerable<User> FindMany();
        public User? FindOne(Guid id);

    }
}