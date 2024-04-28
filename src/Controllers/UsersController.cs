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
    }
}