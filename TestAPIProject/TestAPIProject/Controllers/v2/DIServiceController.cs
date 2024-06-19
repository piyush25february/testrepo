using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPIProject.Interface;

namespace TestAPIProject.Controllers.v2
{
    [Route("api/v2/[controller]")]
    [ApiController]
    public class DIServiceController : ControllerBase
    {
        private readonly IUserInterface _user;

        public DIServiceController(IUserInterface user)
        {
            _user = user;
        }

        [HttpGet]
        public ActionResult<string> GetDiData()
        {
            var result = _user.DoSomething();
            return result;
        }
    }
}
