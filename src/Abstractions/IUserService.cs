using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IUserService
    {
        public IEnumerable<UserReadDto> FindMany();
        public Task<UserReadDto?> FindOne(Guid userId);

        public Task<User> CreateOne(User newUser);
        public Task<User?> UpdateOne(Guid userId, User UpdatedUser);
        public Task<User?> DeleteOne(Guid userId);

    }
}