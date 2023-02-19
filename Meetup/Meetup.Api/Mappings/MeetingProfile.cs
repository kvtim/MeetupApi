using AutoMapper;
using Meetup.Domain.Models;
using Meetup.Infrastructure.Dtos.Meeting;

namespace Meetup.Api.Mappings
{
    public class MeetingProfile : Profile
    {
        public MeetingProfile()
        {
            CreateMap<Meeting, CreateMeetingDto>().ReverseMap();
            CreateMap<Meeting, UpdateMeetingDto>().ReverseMap();
            CreateMap<Meeting, MeetingDto>().ReverseMap();
        }
    }
}
