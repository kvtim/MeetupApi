using AutoMapper;
using Meetup.Core.Models;
using Meetup.Core.Services;
using Meetup.Data.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meetup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTTokenService _jwttokenService;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IJWTTokenService jWTTokenServices,
            IMapper mapper)
        {
            _userService = userService;
            _jwttokenService = jWTTokenServices;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserDto loginUserDto)
        {
            var token = _jwttokenService
                .Authenticate(loginUserDto.UserName, loginUserDto.Password);

            if (token == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            var newUser = await _userService.AddAsync(_mapper.Map<User>(registerUserDto));

            if (newUser == null)
            {
                return BadRequest(new { message = "User already exists" });
            }

            var token = _jwttokenService.Authenticate(newUser.UserName, newUser.Password);
            return Ok(token);
        }
    }
}
