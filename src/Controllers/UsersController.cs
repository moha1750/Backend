using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<UserReadDto> FindMany([FromQuery(Name = "limit")] int limit, [FromQuery(Name = "offset")] int offset)
        {
            return _userService.FindMany(limit, offset);
        }

        [HttpGet(":{userId}")]
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

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> CreateOne([FromBody] UserCreateDto newUser)
        {
            return await _userService.CreateOne(newUser);
        }

        [HttpPut(":{userId}")]
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