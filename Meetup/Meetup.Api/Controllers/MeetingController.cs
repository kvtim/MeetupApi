using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Meetup.Api.Controllers
{
    [Route("api/[controller]")]
    public class MeetingController : BaseController
    {
        // GET: api/<MeetingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MeetingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MeetingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MeetingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MeetingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
