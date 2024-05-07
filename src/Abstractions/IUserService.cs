using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IUserService
    {
        public IEnumerable<UserReadDto> FindMany(int limit, int offset);
        public Task<UserReadDto?> FindOne(Guid userId);
        public Task<UserReadDto> FindOneByEmail(string email);

        public Task<UserReadDto> CreateOne(UserCreateDto newUser);
        public Task<UserReadDto?> UpdateOne(Guid userId, UserUpdateDto UpdatedUser);
        public Task<UserReadDto?> DeleteOne(Guid userId);
        public IEnumerable<UserReadDto> Search(string searchTerm);

    }
}