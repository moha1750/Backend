using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IUsersService
    {
        public IEnumerable<Users> FindMany();
    }
}