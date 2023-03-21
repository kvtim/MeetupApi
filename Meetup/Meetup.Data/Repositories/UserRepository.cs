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
                .SingleAsync(u => u.UserName == userName);
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
            if (_dbSet.Any(e => e.UserName == user.UserName)) return null;

            await _dbSet.AddAsync(user);
            return user;
        }

        public async Task<Meeting> BecomeMemberAsync(int meetingId, string userName)
        {
            var meeting = await _dbContext.Meetings.Include(u => u.Users)
                .FirstAsync(m => m.Id == meetingId);

            if (meeting.Users.Any(u => u.UserName == userName))
                throw new ArgumentException("You already have this meetup");

            _dbSet.First(u => u.UserName == userName)
                 .Meetings.Add(meeting);

            return meeting;
        }

        public async Task<User> RefuseToMeetingAsync(int meetingId, string userName)
        {
            var user = await GetByUserNameAsync(userName);
            var meeting = user.Meetings.First(m => m.Id == meetingId);

            user.Meetings.Remove(meeting);

            return user;
        }
    }
}
