using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserForLoginDto
    {
        public string EmailOrUserName { get; set; }
        public string Password { get; set; }
    }
}