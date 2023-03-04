namespace Meetup.Domain.Models
{
    public class Speaker : Participant
    {
        public string? Report { get; set; }

        public Meeting? SpeakerMeeting { get; set; }
    }
}
