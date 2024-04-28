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
        public IEnumerable<User> FindMany()
        {
            return _UserService.FindMany();
        }

        [HttpGet(":{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(200)]
        public ActionResult<User> FindOne(string id)
        {
            User? user = _UserService.FindOne(new Guid(id));
            if (user is not null)
            {
                return user;
            }
            return NoContent();
        }

    }
}