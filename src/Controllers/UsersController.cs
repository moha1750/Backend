using BackendTeamwork.Abstractions;
using BackendTeamwork.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendTeamwork.Controllers
{
    public class UsersController : BaseController
    {
        private IUsersService _UsersService;

        public UsersController(IUsersService UsersService)
        {
            _UsersService = UsersService;
        }

        [HttpGet]
        public IEnumerable<Users> FindMany()
        {
            return _UsersService.FindMany();
        }
    }
}