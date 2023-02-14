namespace Meetup.Core.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int MeetingId { get; set; }
        public Meeting? Meeting { get; set; }
    }
}
