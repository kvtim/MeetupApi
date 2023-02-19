using Meetup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Domain.Repositories
{
    public interface IMeetingRepository : IRepository<Meeting>
    {
    }
}
