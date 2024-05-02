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
        public async Task<User?> FindOne(Guid id)
        {
            return await _UserRepository.FindOne(id);
        }

        public async Task<User> CreateOne(User newUser)
        {
            return await _UserRepository.CreateOne(newUser);
        }

        public async Task<User?> UpdateOne(Guid userId, User updatedUser)
        {
            User? targetUser = await _UserRepository.FindOne(userId);
            if (targetUser is null)
            {
                return null;
            }
            return await _UserRepository.UpdateOne(updatedUser);
        }

        public async Task<User?> DeleteOne(Guid userId)
        {
            User? deletedUser = await _UserRepository.FindOne(userId);
            if (deletedUser is null)
            {
                return null;
            }
            return await _UserRepository.DeleteOne(deletedUser);
        }


    }
}