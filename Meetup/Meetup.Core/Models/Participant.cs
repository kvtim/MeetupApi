namespace Meetup.Domain.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int ParticipantMeetingId { get; set; }
        public Meeting? ParticipantMeeting { get; set; }
    }
}
