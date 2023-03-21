using Meetup.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Core.Services
{
    public interface IUserService
    {
        Task<User> GetByUserNameAsync(string id);
        Task<IEnumerable<User>> GetAll();
        Task<User> AddAsync(User user);
        Task<IEnumerable<Meeting>> GetUserMeetings(string userName);
        Task<Meeting> BecomeMember(int meetingId, string userName);
        Task<User> RefuseToMeeting(int meetingId, string userName);
    }
}
