using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPIProject.Interface;

namespace TestAPIProject.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IUserInterface _user;
        public UserController(IUserInterface user)
        {
            _user = user;
        }

        [HttpGet]
        public ActionResult<string> UserIsAuth()
        {
            var result=_user.DoSomething();
            return result;
        }
    }
}
