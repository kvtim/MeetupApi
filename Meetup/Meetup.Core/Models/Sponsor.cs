namespace Meetup.Domain.Models
{
    public class Sponsor : Participant
    {
        public int Investment { get; set; }

        public int SponsorMeetingId { get; set; }
        public Meeting? SponsorMeeting { get; set; }
    }
}
