using Meetup.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByIdWithMeetingsAsync(int id);
        Task<IEnumerable<User>> GetAllWithMeetingsAsync();
        Task<User> GetByUserNameAsync(string userName);
        Task<IEnumerable<Meeting>> GetUserMeetingsAsync(string userName);
        Task<User> CheckedAddAsync(User user);
        Task<Meeting> BecomeMemberAsync(int meetingId, string userName);
        Task<User> RefuseToMeetingAsync(int meetingId, string userName);
    }
}
