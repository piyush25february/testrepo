using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPIProject.Interface;

namespace TestAPIProject.Services
{
    public class User : IUserInterface
    {
        public string DoSomething()
        {
            return "I am User";
        }
    }
}
