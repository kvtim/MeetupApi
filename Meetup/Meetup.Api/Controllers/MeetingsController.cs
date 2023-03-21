using AutoMapper;
using Meetup.Core.Models;
using Meetup.Core.Services;
using Meetup.Data.Dtos.Meeting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Meetup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public MeetingsController(IMeetingService meetingService, IMapper mapper,
            IUserService userService)
        {
            _meetingService = meetingService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var meetings = await _meetingService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<MeetingDto>>(meetings));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var meeting = await _meetingService.GetByIdAsync(id);

            return meeting == null ? NotFound() : Ok(_mapper.Map<MeetingDto>(meeting));
        }

        [HttpPost]
        [Authorize(Roles = "Owner, Admin")]
        public async Task<IActionResult> Add([FromBody] CreateMeetingDto createMeetingDto)
        {
            var user = await _userService.GetByUserNameAsync(User.Identity.Name);

            var meeting = _mapper.Map<Meeting>(createMeetingDto);
            meeting.Users.Add(user);

            var meetingResult = await _meetingService.AddAsync(meeting);

            if (meetingResult == null) return BadRequest();

            return Ok(_mapper.Map<MeetingDto>(meetingResult));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Owner, Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMeetingDto updateMeetingDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var meeting = _mapper.Map<Meeting>(updateMeetingDto);
            meeting.Id = id;

            var user = await _userService.GetByUserNameAsync(User.Identity.Name);

            if (user.Role == Role.Owner && !user.Meetings.Any(m => m.Id == id))
                return BadRequest("You don't have this meetup");

            await _meetingService.UpdateAsync(meeting);

            return Ok(updateMeetingDto);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Owner, Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetByUserNameAsync(User.Identity.Name);

            if (user.Role == Role.Owner && !user.Meetings.Any(m => m.Id == id))
                return BadRequest("You don't have this meetup");

            var meeting = await _meetingService.GetByIdAsync(id);
            if (meeting == null) return BadRequest("Meetup not found");

            await _meetingService.RemoveAsync(meeting);
            return Ok();
        }
    }
}
