using Meetup.Domain.Models;
using Meetup.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Infascructure.Repositories
{
    public class MeetingRepository : Repository<Meeting>, IMeetingRepository
    {
        public MeetingRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
