﻿using Meetup.Core.Models;
using Meetup.Data.Dtos.Meeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Data.Dtos.User
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public Role Role { get; set; }

        public List<MeetingWithoutUsersDto>? Meetings { get; set; }
    }
}
