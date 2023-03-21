using AutoMapper;
using Meetup.Core.Models;
using Meetup.Core.Services;
using Meetup.Data.Dtos.Meeting;
using Meetup.Data.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meetup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAll();
            return Ok(_mapper.Map<IEnumerable<UserDto>>(users));
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _userService.GetByUserNameAsync(User.Identity.Name);
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpGet("myMeetings")]
        [Authorize]
        public async Task<IActionResult> GetMyMeetings()
        {
            var meetings = await _userService.GetUserMeetings(User.Identity.Name);

            return Ok(_mapper.Map<IEnumerable<MeetingDto>>(meetings));
        }

        [HttpGet("becomeMember/{id}")]
        [Authorize]
        public async Task<IActionResult> BecomeMember(int id)
        {
            var meeting = await _userService.BecomeMember(id, User.Identity.Name);

            if (meeting == null)
                return BadRequest("Meetup doesn't exist");

            return Ok(_mapper.Map<MeetingDto>(meeting));
        }

        [HttpGet("refuseToMeeting/{id}")]
        [Authorize]
        public async Task<IActionResult> RefuseToMeeting(int id)
        {
            var user = await _userService.RefuseToMeeting(id, User.Identity.Name);

            if (user == null)
                return BadRequest("You aren't member of this meetup");

            return Ok(_mapper.Map<UserDto>(user));
        }
    }
}
