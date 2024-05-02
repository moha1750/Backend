using BackendTeamwork.Abstractions;
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
        public IEnumerable<User> FindMany()
        {
            return _UserService.FindMany();
        }

        [HttpGet(":{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> FindOne(Guid userId)
        {
            User? user = await _UserService.FindOne(userId);
            if (user is not null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateOne([FromBody] User newUser)
        {
            return await _UserService.CreateOne(newUser);
        }

        [HttpPut(":{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> UpdateOne(Guid userId, [FromBody] User updatedUser)
        {
            User? user = await _UserService.UpdateOne(userId, updatedUser);
            if (user is not null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpDelete(":{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<User>> DeleteOne(Guid userId)
        {
            User? deletedUser = await _UserService.DeleteOne(userId);
            if (deletedUser is not null)
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}