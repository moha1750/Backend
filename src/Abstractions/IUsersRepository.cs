using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IUsersRepository
    {
        public IEnumerable<Users> FindMany();
    }
}