using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public IEnumerable<User> FindMany()
        {
            return _UserRepository.FindMany();
        }
        public User? FindOne(Guid id)
        {
            User? user = _UserRepository.FindOne(id);
            return user;
        }

        public User CreateOne(User newUser)
        {
            return _UserRepository.CreateOne(newUser);
        }
    }
}