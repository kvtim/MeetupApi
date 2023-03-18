﻿namespace Meetup.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public Role Role { get; set; }

        public List<Meeting> Meetings { get; set; }
    }
}
