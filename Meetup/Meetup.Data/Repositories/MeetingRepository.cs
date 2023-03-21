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
    public class MeetingRepository : Repository<Meeting>, IMeetingRepository
    {
        public MeetingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Meeting> GetByIdAsync(int id)
        {
            return await _dbSet.Include(c => c.Users).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Meeting>> GetAllAsync()
        {
            return await _dbSet.Include(c => c.Users).ToListAsync();
        }
    }
}
