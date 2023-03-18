using Meetup.Domain.Models;
using Meetup.Infrastructure.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Infrastructure.Dtos.Meeting
{
    public class MeetingDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime? MeetingTime { get; set; }

        public List<UserDto>? Users { get; set; }
    }
}
