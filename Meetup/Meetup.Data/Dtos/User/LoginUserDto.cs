﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Infrastructure.Dtos.User
{
    public class LoginUserDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
