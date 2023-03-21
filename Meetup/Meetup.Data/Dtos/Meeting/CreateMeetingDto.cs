using System.ComponentModel.DataAnnotations;

namespace Meetup.Data.Dtos.Meeting
{
    public class CreateMeetingDto
    {
        public required string? Title { get; set; }

        public required string? Description { get; set; }

        public required string? Location { get; set; }

        public DateTime? MeetingTime { get; set; }
    }
}
