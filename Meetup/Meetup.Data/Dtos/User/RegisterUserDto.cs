﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Data.Dtos.User
{
    public class RegisterUserDto
    {
        public required string? FirstName { get; set; }

        public required string? LastName { get; set; }

        [EmailAddress]
        public required string? Email { get; set; }

        [MinLength(3), MaxLength(32)]
        public required string? UserName { get; set; }

        [MinLength(6), MaxLength(127)]
        public required string? Password { get; set; }
    }
}
