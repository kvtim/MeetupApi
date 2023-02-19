using Meetup.Domain.Models;
using Meetup.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Infascructure.Repositories
{
    public class ParticipantRepository : Repository<Participant>, IParticipantRepository
    {
        public ParticipantRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
