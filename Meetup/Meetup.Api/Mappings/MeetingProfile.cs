using AutoMapper;
using Meetup.Core.Models;
using Meetup.Data.Dtos.Meeting;
using Meetup.Data.Dtos.User;

namespace Meetup.Api.Mappings
{
    public class MeetingProfile : Profile
    {
        public MeetingProfile()
        {
            CreateMap<Meeting, CreateMeetingDto>().ReverseMap();
            CreateMap<Meeting, UpdateMeetingDto>().ReverseMap();
            CreateMap<Meeting, MeetingDto>().ReverseMap();
            CreateMap<Meeting, MeetingWithoutUsersDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();
            CreateMap<User, UserWithoutMeetingsDto>().ReverseMap();
        }
    }
}
