using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackendTeamwork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : BaseController
    {
        [HttpGet]
        public string Hello()
        {
            return "test";
        }
    }
}