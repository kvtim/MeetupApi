using AutoMapper;
using Meetup.Domain.Models;
using Meetup.Infrastructure.Dtos.Meeting;
using Meetup.Infrastructure.Dtos.User;

namespace Meetup.Api.Mappings
{
    public class MeetingProfile : Profile
    {
        public MeetingProfile()
        {
            CreateMap<Meeting, CreateMeetingDto>().ReverseMap();
            CreateMap<Meeting, UpdateMeetingDto>().ReverseMap();
            CreateMap<Meeting, MeetingDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();
        }
    }
}
