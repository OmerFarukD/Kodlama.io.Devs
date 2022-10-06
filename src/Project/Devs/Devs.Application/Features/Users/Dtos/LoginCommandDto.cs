using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Application.Features.Users.Dtos
{
    public class LoginCommandDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
