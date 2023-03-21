using System.ComponentModel.DataAnnotations;

namespace Meetup.Data.Dtos.Meeting
{
    public class CreateMeetingDto
    {
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Location { get; set; }

        public DateTime? MeetingTime { get; set; }
    }
}
