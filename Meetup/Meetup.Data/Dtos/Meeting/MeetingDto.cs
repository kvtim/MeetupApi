using Meetup.Core.Models;
using Meetup.Data.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Data.Dtos.Meeting
{
    public class MeetingDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime? MeetingTime { get; set; }

        public List<UserWithoutMeetingsDto>? Users { get; set; }
    }
}
