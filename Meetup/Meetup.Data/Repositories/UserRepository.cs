using Meetup.Core.Models;
using Meetup.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetByIdWithMeetingsAsync(int id)
        {
            return await _dbSet.Include(c => c.Meetings).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllWithMeetingsAsync()
        {
            return await _dbSet.Include(u => u.Meetings).ToListAsync();
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _dbSet.Include(c => c.Meetings)
                .FirstAsync(u => u.UserName == userName);
        }

        public async Task<IEnumerable<Meeting>> GetUserMeetingsAsync(string userName)
        {
            return await _dbContext.Meetings.Include(u => u.Users)
                .Where(
                m => m.Users
                .Any(u => u.UserName == userName)
                ).ToListAsync();
        }

        public async Task<User> CheckedAddAsync(User user)
        {
            if (_dbSet.Any(e => e.UserName == user.UserName
            && e.Password == user.Password))
            {
                return null;
            }

            await _dbSet.AddAsync(user);
            return user;
        }

        public async Task<Meeting> BecomeMemberAsync(int meetingId, string userName)
        {
            var meeting = await _dbContext.Meetings.Include(u => u.Users)
                .FirstOrDefaultAsync(m => m.Id == meetingId);

            if (meeting == null) return null;

            if (meeting.Users.Exists(u => u.UserName == userName))
                return null; // need update

            _dbSet.First(u => u.UserName == userName)
                 .Meetings.Add(meeting);

            return meeting;
        }

        public async Task<User> RefuseToMeetingAsync(int meetingId, string userName)
        {
            var user = await GetByUserNameAsync(userName);
            var meeting = user.Meetings.FirstOrDefault(m => m.Id == meetingId);

            if (meeting == null) return null;

            user.Meetings.Remove(meeting);

            return user;
        }
    }
}
