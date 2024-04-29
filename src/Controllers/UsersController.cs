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
        // [ProducesResponseType(StatusCodes.Status204NoContent)]
        // [ProducesResponseType(200)]
        public IEnumerable<User> FindMany()
        {
            return _UserService.FindMany();
        }

        [HttpGet(":{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<User> FindOne(string id)
        {
            User? user = _UserService.FindOne(new Guid(id));
            if (user is not null)
            {
                return user;
            }
            return NoContent();
        }

        [HttpPost]
        public ActionResult<User> CreateOne([FromBody] User newUser)
        {
            return _UserService.CreateOne(newUser);
        }

        [HttpPut]
        public User UpdateOne([FromBody] User updatedUser)
        {
            return _UserService.UpdateOne(updatedUser);
        }

        [HttpDelete(":{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteOne(Guid id)
        {
            bool response = _UserService.DeleteOne(id);
            if (response)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteMany([FromBody] IEnumerable<Guid> ids)
        {
            bool response = _UserService.DeleteMany(ids);
            if (response)
            {
                return NoContent();
            }
            return NotFound();
        }

    }
}