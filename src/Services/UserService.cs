using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using BackendTeamwork.Utils;
using Microsoft.IdentityModel.Tokens;

namespace BackendTeamwork.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _UserRepository;
        private IConfiguration _config;
        private IMapper _mapper;

        public UserService(IUserRepository UserRepository, IConfiguration config, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _config = config;
            _mapper = mapper;
        }

        public IEnumerable<UserReadDto> FindMany(int limit, int offset)
        {
            return _UserRepository.FindMany(limit, offset).Select(_mapper.Map<UserReadDto>);
        }
        public async Task<UserReadDto?> FindOne(Guid userId)
        {
            return _mapper.Map<UserReadDto>(await _UserRepository.FindOne(userId));
        }

        public async Task<UserReadDto> FindOneByEmail(string email)
        {
            return _mapper.Map<UserReadDto>(await _UserRepository.FindOneByEmail(email));
        }



        public async Task<UserReadDto?> SignUp(UserCreateDto newUser)
        {
            User? user = await _UserRepository.FindOneByEmail(newUser.Email);
            if (user is null) return null;
            byte[] pepper = Encoding.UTF8.GetBytes(_config["Jwt:Pepper"]!);
            PasswordUtils.HashPassword(newUser.Password, out string hashedPassword, pepper);
            newUser.Password = hashedPassword;
            return _mapper.Map<UserReadDto>(await _UserRepository.SignUp(_mapper.Map<User>(newUser)));
        }

        public async Task<string?> SignIn(UserSignInDto userSignIn)
        {
            User? user = await _UserRepository.FindOneByEmail(userSignIn.Email);
            if (user is null) return null;

            byte[] pepper = Encoding.UTF8.GetBytes(_config["Jwt:Pepper"]!);
            bool isCorrectPass = PasswordUtils.VerifyPassword(userSignIn.Password, user.Password, pepper);

            if (!isCorrectPass) return null;

            IEnumerable<Claim> claims = [
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            ];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SigningKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        public async Task<UserReadDto?> UpdateOne(Guid userId, UserUpdateDto updatedUser)
        {
            User? targetUser = await _UserRepository.FindOne(userId);
            if (targetUser is null)
            {
                return null;
            }
            targetUser.FirstName = updatedUser.FirstName;
            targetUser.LastName = updatedUser.LastName;
            targetUser.Phone = updatedUser.Phone;
            targetUser.Role = updatedUser.Role;
            return _mapper.Map<UserReadDto>(await _UserRepository.UpdateOne(targetUser));
        }

        public async Task<UserReadDto?> DeleteOne(Guid userId)
        {
            User? deletedUser = await _UserRepository.FindOne(userId);
            if (deletedUser is null)
            {
                return null;
            }
            return _mapper.Map<UserReadDto>(await _UserRepository.DeleteOne(deletedUser));
        }


    }
}