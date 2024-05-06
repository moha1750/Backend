using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;

namespace BackendTeamwork.Abstractions
{
    public interface IUserService
    {
        public IEnumerable<UserReadDto> FindMany(int limit, int offset);
        public Task<UserReadDto?> FindOne(Guid userId);
        public Task<UserReadDto> FindOneByEmail(string email);

        public Task<UserReadDto?> SignUp(UserCreateDto newUser);

        public Task<string?> SignIn(UserSignInDto userSignIn);
        public Task<UserReadDto?> UpdateOne(Guid userId, UserUpdateDto UpdatedUser);
        public Task<UserReadDto?> DeleteOne(Guid userId);

    }
}