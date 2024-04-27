using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using BackendTeamwork.Repositories;

namespace BackendTeamwork.Services
{
    public class UsersService : IUsersService
    {
        private IUsersRepository _UsersRepository;

        public UsersService(IUsersRepository UsersRepository)
        {
            _UsersRepository = UsersRepository;
        }

        public IEnumerable<Users> FindMany()
        {
            return _UsersRepository.FindMany();
        }
    }
}