namespace Meetup.Domain.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public DateTime? MeetingTime { get; set; }

        public int SpeakerId { get; set; }
        public Speaker? Speaker { get; set; }

        public List<Sponsor>? Sponsors { get; set; }
        public List<Participant>? Participants { get; set; }
    }
}
