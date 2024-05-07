using System.Reflection;
using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Authorization;
using BackendTeamwork.Enums;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class UsersController : BaseController
    {
        private IUserService _userService;

        public UsersController(IUserService UserService)
        {
            _userService = UserService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<UserReadDto> FindMany([FromQuery(Name = "limit")] int limit, [FromQuery(Name = "offset")] int offset, [FromQuery(Name = "sort")] SortBy sortBy)
        {
            return _userService.FindMany(limit, offset, sortBy);
        }

        [HttpGet(":{userId}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserReadDto>> FindOne(Guid userId)
        {
            UserReadDto? user = await _userService.FindOne(userId);
            if (user is not null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpGet("email/:{email}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserReadDto>> FindOneByEmail(string email)
        {
            UserReadDto? user = await _userService.FindOneByEmail(email);
            if (user is not null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost("signUp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserReadDto>> SignUp([FromBody] UserCreateDto newUser)
        {
            UserReadDto? user = await _userService.SignUp(newUser);

            if (user is null) return BadRequest();

            return Ok(user);
        }

        [HttpPost("signIn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserReadDto>> SignIn([FromBody] UserSignInDto userSignIn)
        {
            string? token = await _userService.SignIn(userSignIn);
            if (token is null) return BadRequest();
            return Ok(token);
        }

        [HttpPut(":{userId}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserReadDto>> UpdateOne(Guid userId, [FromBody] UserUpdateDto updatedUser)
        {
            UserReadDto? user = await _userService.UpdateOne(userId, updatedUser);
            if (user is not null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpDelete(":{userId}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserReadDto>> DeleteOne(Guid userId)
        {
            UserReadDto? deletedUser = await _userService.DeleteOne(userId);
            if (deletedUser is not null)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<UserReadDto>> Search(string searchTerm)
        {
            return Ok(_userService.Search(searchTerm));
        }


    }
}