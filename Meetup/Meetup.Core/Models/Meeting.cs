namespace Meetup.Domain.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime? MeetingTime { get; set; }

        public List<User>? Users { get; set; }
    }
}
