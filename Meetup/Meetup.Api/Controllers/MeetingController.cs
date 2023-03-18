using AutoMapper;
using Meetup.Domain.Models;
using Meetup.Domain.Services;
using Meetup.Infrastructure.Dtos.Meeting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meetup.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class MeetingController : BaseController
    {
        private readonly IMeetingService _meetingService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public MeetingController(IMeetingService meetingService, IMapper mapper,
            IUserService userService)
        {
            _meetingService = meetingService;
            _mapper = mapper;
            _userService = userService;
        }

        // GET: api/<MeetingController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var meetings = await _meetingService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<MeetingDto>>(meetings));
        }

        // GET api/<MeetingController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var meeting = await _meetingService.GetByIdAsync(id);

            return meeting == null ? NotFound() : Ok(_mapper.Map<MeetingDto>(meeting));
        }

        // POST api/<MeetingController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] CreateMeetingDto createMeetingDto)
        {
            var user = await _userService.GetByUserNameAsync(User.Identity.Name);

            var meeting = _mapper.Map<Meeting>(createMeetingDto);
            meeting.Users = new List<User> { user };

            var meetingResult = await _meetingService.AddAsync(meeting);

            if (meetingResult == null) return BadRequest();

            return Ok(_mapper.Map<MeetingDto>(meetingResult));
        }

        // PUT api/<MeetingController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] MeetingDto meetingDto)
        {
            //if (id != meetingDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var meeting = _mapper.Map<Meeting>(meetingDto);
            meeting.Id = id;
            await _meetingService.UpdateAsync(meeting);

            return Ok(meetingDto);
        }

        // DELETE api/<MeetingController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _meetingService.GetByIdAsync(id);
            if (category == null) return NotFound();

            await _meetingService.RemoveAsync(category);

            return Ok();
        }
    }
}
