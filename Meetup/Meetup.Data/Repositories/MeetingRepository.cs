using Meetup.Core.Models;
using Meetup.Core.Repositories;
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
    }
}
