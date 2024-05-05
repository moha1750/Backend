using BackendTeamwork.Abstractions;
using BackendTeamwork.DTOs;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class UsersController : BaseController
    {
        private IUserService _UserService;

        public UsersController(IUserService UserService)
        {
            _UserService = UserService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<UserReadDto> FindMany([FromQuery(Name = "limit")] int limit, [FromQuery(Name = "offset")] int offset)
        {
            return _UserService.FindMany(limit, offset);
        }

        [HttpGet(":{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserReadDto>> FindOne(Guid userId)
        {
            UserReadDto? user = await _UserService.FindOne(userId);
            if (user is not null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> CreateOne([FromBody] UserCreateDto newUser)
        {
            return await _UserService.CreateOne(newUser);
        }

        [HttpPut(":{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserReadDto>> UpdateOne(Guid userId, [FromBody] UserUpdateDto updatedUser)
        {
            UserReadDto? user = await _UserService.UpdateOne(userId, updatedUser);
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
            UserReadDto? deletedUser = await _UserService.DeleteOne(userId);
            if (deletedUser is not null)
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}